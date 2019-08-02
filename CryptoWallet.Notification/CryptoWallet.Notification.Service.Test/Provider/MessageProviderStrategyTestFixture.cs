using Xunit;
using CryptoWallet.Service.Provider;
using Moq;
using CryptoWallet.Service.Notification;
using CryptoWallet.Notification.Messaging.Email;
using CryptoWallet.Notification.Messaging.Sms;
using CryptoWallet.Notification.Common.Interface.Common;

namespace CryptoWallet.Notification.Service.Test
{
    public class MessageProviderStrategyTestFixture
    {
        EmailMessageProvider emailProvider;
        SmsMessageProvider smsProvider;

        public MessageProviderStrategyTestFixture()
        {
            Mock<IAppSettings> appSettings = new Mock<IAppSettings>();

            emailProvider = new EmailMessageProvider(appSettings.Object);
            smsProvider = new SmsMessageProvider();
        }

        [Fact]
        public void GetMessageProvider_GvenEmailNotificationType_EmailProviderReturned()
        {
            //Arrange
            var MessageProviderStrategy = new MessageProviderStrategy(emailProvider, smsProvider);

            //Act
            var provider = MessageProviderStrategy.GetMessageProvider(NotificationMessageType.Email);

            //Assert
            Assert.IsAssignableFrom<EmailMessageProvider>(provider);
        }

        [Fact]
        public void GetMessageProvider_GvenSmsNotificationType_SmsProviderReturned()
        {
            //Arrange
            var MessageProviderStrategy = new MessageProviderStrategy(emailProvider, smsProvider);

            //Act
            var provider = MessageProviderStrategy.GetMessageProvider(NotificationMessageType.Sms);

            //Assert
            Assert.IsAssignableFrom<SmsMessageProvider>(provider);
        }
    }
}
