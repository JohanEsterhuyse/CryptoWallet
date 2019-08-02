using CryptoWallet.Service.Notification;
using System;
using CryptoWallet.Notification.Common.Interface.Provider;
using CryptoWallet.Notification.Messaging.Email;
using CryptoWallet.Notification.Messaging.Sms;

namespace CryptoWallet.Service.Provider
{
    public class MessageProviderStrategy
    {
        private readonly EmailMessageProvider _emailMessageProvider;
        private readonly SmsMessageProvider _smsMessageProvider;


        public MessageProviderStrategy(EmailMessageProvider emailMessageProvider,
            SmsMessageProvider smsMessageProvider)
        {
            _emailMessageProvider = emailMessageProvider;
            _smsMessageProvider = smsMessageProvider;
        }

        public IMessageProvider GetMessageProvider(NotificationMessageType messageType)
        {
            switch (messageType)
            {
                case NotificationMessageType.Email:
                    return _emailMessageProvider;
                case NotificationMessageType.Sms:
                    return _smsMessageProvider;
                default:
                    throw new NotImplementedException("Invalid message Type");
            }
        }
    }
}
