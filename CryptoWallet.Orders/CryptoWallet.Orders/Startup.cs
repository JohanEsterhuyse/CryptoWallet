using System;
using CryptoWallet.Notification.Common;
using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Orders.Common.Interface.DAL;
using CryptoWallet.Orders.DAL.Sql.Repositories;
using CryptoWallet.Orders.Domain;
using CryptoWallet.Orders.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoWallet.Orders
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvcCore()
                           .AddAuthorization()
                           .AddJsonFormatters();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                                           JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                                           JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "https://localhost:44383";
                o.Audience = "apiApp";
                o.RequireHttpsMetadata = false;
            });

            //TODO: Change DI to use catalogs so that every layer becomes responsible for its own dependencies
            var envname = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile($"appsettings.{envname}.json", optional: true)
             .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            var appSettings = new AppSettings(configuration);

            services.AddSingleton<IAppSettings>(appSettings);

            services.AddScoped<OrderContext>();
            services.AddScoped<IRepository<Trade>,TradeRepository>();
            services.AddScoped<TradeService>();

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
