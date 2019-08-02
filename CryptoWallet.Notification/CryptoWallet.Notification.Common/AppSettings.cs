using CryptoWallet.Notification.Common.Interface.Common;
using Microsoft.Extensions.Configuration;

namespace CryptoWallet.Notification.Common
{
    public class AppSettings : IAppSettings
    {
        public string SmtpServer { get; private set; }

        public string SmtpUserName { get; private set; }

        public string SmtpPassword { get; private set; }

        public AppSettings(IConfiguration Configuration)
        {
            SmtpServer = Configuration["SmtpServer"];
            SmtpUserName = Configuration["SmtpUserName"];
            SmtpPassword = Configuration["SmtpPassword"];
        }
    }
}
