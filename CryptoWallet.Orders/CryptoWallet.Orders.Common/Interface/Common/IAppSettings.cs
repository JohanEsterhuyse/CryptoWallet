namespace CryptoWallet.Notification.Common.Interface.Common
{
    public interface IAppSettings
    {
        //Your settings here
        string ConnectionString { get; }

        string NotificationApiBase { get; }

        //TODO: Should be encrypted
        string NotificationUserName { get; }

        //TODO: Should be encrypted
        string NotificationPassword { get; }

        int OrderAlertAmount { get; }
    }
}
