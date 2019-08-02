using CryptoWallet.Notification.Interface.Model;
using CryptoWallet.Notification.Interface.Provider;

namespace CryptoWallet.Notification.Email.Provider
{
    public class EmailMessageProvider : IEmailMessageProvider
    {
        public bool SendMessage(INotificationMessage notificationMessage)
        {
            //Send the email
            return true;
        }
    }
}
