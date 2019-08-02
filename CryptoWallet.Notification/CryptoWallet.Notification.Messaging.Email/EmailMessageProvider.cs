using CryptoWallet.Notification.Common.Interface.Provider;
using CryptoWallet.Notification.Domain.Notification;

namespace CryptoWallet.Notification.Messaging.Email
{
    public class EmailMessageProvider : IMessageProvider
    {
        public bool SendMessage(NotificationMessage notificationMessage)
        {
            //TODO: send message
            return true;
        }
    }
}
