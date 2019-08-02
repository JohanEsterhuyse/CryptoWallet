using CryptoWallet.Notification.Service.Mappers;
using CryptoWallet.Service.Notification;
using CryptoWallet.Service.Provider;

namespace CryptoWallet.Notification.Service
{
    public class NotificationsService
    {
        private MessageProviderStrategy messageProviderStrategy;

        public NotificationsService(MessageProviderStrategy messageProviderStrategy)
        {
            this.messageProviderStrategy = messageProviderStrategy;
        }

        public void SendNotification(NotificationMessageDto notificationMessageDto)
        {
            var messageProvider = messageProviderStrategy.GetMessageProvider(notificationMessageDto.MessageType);
            var message = NotificationMessageMapper.DtoToDomain(notificationMessageDto);

            messageProvider.SendMessage(message);
        }
    }
}
