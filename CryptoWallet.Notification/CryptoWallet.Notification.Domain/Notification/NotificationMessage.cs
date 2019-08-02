namespace CryptoWallet.Notification.Domain.Notification
{
    public class NotificationMessage
    {
        public string Recipient { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
