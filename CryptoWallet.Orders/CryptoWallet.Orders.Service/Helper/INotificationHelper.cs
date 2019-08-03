using CryptoWallet.Orders.Domain.Model;

namespace CryptoWallet.Orders.Service.Helper
{
    public interface INotificationHelper
    {
        void SendNotificationMessage(NotificationMessage notificationMessage);
    }
}
