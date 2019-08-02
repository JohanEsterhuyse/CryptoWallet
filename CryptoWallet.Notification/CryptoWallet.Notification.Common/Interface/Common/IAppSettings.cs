namespace CryptoWallet.Notification.Common.Interface.Common
{
    public interface IAppSettings
    {
        //Your settings here
        string SmtpServer { get; }

        string SmtpUserName { get; }

        string SmtpPassword { get; }
    }
}
