using CryptoWallet.Notification.Common;
using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Notification.Service;
using CryptoWallet.Service.Provider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoWallet.Notification.Lambda.DependencyInjection
{
    static class DependencyInjectionHelper
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //TODO: Change DI to use catalogs so that every layer becomes responsible for its own dependencies
            var envname = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile($"appsettings.{envname}.json", optional: true)
             .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            //TODO: Fix this AppSettings issue
            //var appSettings = new AppSettings(configuration);

            //services.AddSingleton<IAppSettings>(appSettings);

            services.AddScoped<NotificationsService>();
            services.AddScoped<MessageProviderStrategy>();

            services.AddScoped<MessageProviderStrategy>();

            return services.BuildServiceProvider();
        }
    }
}
