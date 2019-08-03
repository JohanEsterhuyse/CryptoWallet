using CryptoWallet.Notification.Common.Interface.Common;
using Microsoft.Extensions.Configuration;
using System;

namespace CryptoWallet.Notification.Common
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; private set; }

        public string NotificationApiBase { get; private set; }

        public int OrderAlertAmount { get; private set; }

        //TODO: Should be encrypted
        public string NotificationUserName { get; private set; }

        //TODO: Should be encrypted
        public string NotificationPassword { get; private set; }

        public AppSettings(IConfiguration Configuration)
        {
            ConnectionString = Configuration["ConnectionString"];
            NotificationApiBase = Configuration["NotificationApiBase"];
            NotificationUserName = Configuration["NotificationUserName"];
            NotificationPassword = Configuration["NotificationPassword"];
            OrderAlertAmount = Convert.ToInt32(Configuration["OrderAlertAmount"]);
        }
    }
}
