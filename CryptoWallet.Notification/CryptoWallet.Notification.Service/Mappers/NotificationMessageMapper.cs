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
                From = notificationMessageDto.From,
                To = notificationMessageDto.To,
                Body = notificationMessageDto.Message,                
                Subject = notificationMessageDto.Subject
            };
        }
    }
}
