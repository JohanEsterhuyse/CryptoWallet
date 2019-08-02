using CryptoWallet.Notification.Interface.Model;
using CryptoWallet.Notification.Interface.Provider;

namespace CryptoWallet.Notification.Sms.Provider
{
    public class SmsMessageProvider : ISmsMessageProvider
    {
        public bool SendMessage(INotificationMessage notificationMessage)
        {
            //Send the sms
            return true;
        }
    }
}
