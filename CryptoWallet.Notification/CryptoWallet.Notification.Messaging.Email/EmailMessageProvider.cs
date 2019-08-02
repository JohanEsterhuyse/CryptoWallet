using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Notification.Common.Interface.Provider;
using CryptoWallet.Notification.Domain.Notification;
using System.Net;
using System.Net.Mail;

namespace CryptoWallet.Notification.Messaging.Email
{
    public class EmailMessageProvider : IMessageProvider
    {
        private readonly IAppSettings _appSettings;

        public EmailMessageProvider(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public bool SendMessage(NotificationMessage notificationMessage)
        {
            SmtpClient client = new SmtpClient(_appSettings.SmtpServer)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_appSettings.SmtpUserName, _appSettings.SmtpPassword)
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(notificationMessage.From),
                Body = notificationMessage.Body,
                Subject = notificationMessage.Subject
            };

            mailMessage.To.Add(notificationMessage.To);

            client.Send(mailMessage);
            return true;
        }
    }
}
