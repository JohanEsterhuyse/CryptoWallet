using CryptoWallet.Notification.Common.Interface.Common;
using Microsoft.Extensions.Configuration;

namespace CryptoWallet.Notification.Common
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; private set; }

        public AppSettings(IConfiguration Configuration)
        {
            ConnectionString = Configuration["ConnectionString"];
        }
    }
}
