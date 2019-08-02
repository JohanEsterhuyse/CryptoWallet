using CryptoWallet.Notification.Domain.Notification;

namespace CryptoWallet.Notification.Common.Interface.Provider
{
    public interface IMessageProvider
    {
        bool SendMessage(NotificationMessage notificationMessage);
    }
}
