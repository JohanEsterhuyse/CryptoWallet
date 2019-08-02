using CryptoWallet.Notification.Interface.Model;

namespace CryptoWallet.Notification.Interface.Provider
{
    public interface IMessageProvider
    {
        bool SendMessage(INotificationMessage notificationMessage);
    }
}
