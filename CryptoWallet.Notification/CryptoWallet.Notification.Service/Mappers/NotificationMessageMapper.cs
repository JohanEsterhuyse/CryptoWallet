using CryptoWallet.Notification.Domain.Notification;
using CryptoWallet.Service.Notification;

namespace CryptoWallet.Notification.Service.Mappers
{
    public static class NotificationMessageMapper
    {
        public static NotificationMessage DtoToDomain(NotificationMessageDto notificationMessageDto)
        {
            return new NotificationMessage
            {
                Message = notificationMessageDto.Message,
                Recipient = notificationMessageDto.Recipient,
                Subject = notificationMessageDto.Subject
            };
        }
    }
}
