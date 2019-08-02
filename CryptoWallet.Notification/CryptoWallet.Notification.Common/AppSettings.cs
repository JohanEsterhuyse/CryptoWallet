using CryptoWallet.Notification.Common.Interface.Common;
using Microsoft.Extensions.Configuration;

namespace CryptoWallet.Notification.Common
{
    public class AppSettings : IAppSettings
    {
        public AppSettings(IConfiguration Configuration)
        {
            //setting = Configuration["setting"];
        }
    }
}
