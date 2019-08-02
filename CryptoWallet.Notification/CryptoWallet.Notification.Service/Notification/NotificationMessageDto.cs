namespace CryptoWallet.Service.Notification
{
    public class NotificationMessageDto
    {
        public NotificationMessageType MessageType { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
