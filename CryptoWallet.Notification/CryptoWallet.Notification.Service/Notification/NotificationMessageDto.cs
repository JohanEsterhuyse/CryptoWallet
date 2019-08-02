namespace CryptoWallet.Service.Notification
{
    public class NotificationMessageDto
    {
        public NotificationMessageType MessageType { get; set; }

        public string Recipient { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
