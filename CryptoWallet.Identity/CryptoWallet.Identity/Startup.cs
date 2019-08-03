using System.Net;
using CryptoWallet.Identity.Authorize;
using CryptoWallet.Identity.Common.Interface.DAL;
using CryptoWallet.Identity.DAL.Sql;
using CryptoWallet.Identity.Helper;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CryptoWallet.Identity
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters();

            services.AddScoped<IAuthRepository, AuthRepository>(); 
            services.AddScoped<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>(); 
            services.AddScoped<IProfileService, ProfileService>(); 
            services.AddIdentityServer()
                  .AddDeveloperSigningCredential()
                  .AddInMemoryApiResources(Config.GetApiResources())
                  .AddInMemoryClients(Config.GetClients());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            string jsonError = JsonConvert.SerializeObject(Utilities.GetError(123, (int)HttpStatusCode.InternalServerError, "Error", error.Error.Message)); // this creates a new Error object. It needs the Error.cs
                            context.Response.ContentType = "application/json; charset=utf-8";
                            context.Response.AddApplicationError(jsonError); // this adds to the headers the error message. It needs the Extension.cs
                            await context.Response.WriteAsync(jsonError);
                        }
                    });
                });// this will add the global exception handle for production evironment.
            }
            app.UseIdentityServer(); // this will add the IdentityServer
            app.UseMvc();
        }
    }
}
