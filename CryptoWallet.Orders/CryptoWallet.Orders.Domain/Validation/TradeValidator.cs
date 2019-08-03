using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Orders.Domain.Model;
using System;
using System.Collections.Generic;

namespace CryptoWallet.Orders.Domain.Validation
{
    public class TradeValidator
    {
        private readonly IAppSettings _appSettings;

        public TradeValidator(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public IEnumerable<NotificationMessage> Validate(Trade trade)
        {
            var notifications = new List<NotificationMessage>();
            ValidateTradeAmount(trade, notifications);
            ValidateTradeType(trade, notifications);

            return notifications;
        }

        private static void ValidateTradeType(Trade trade, List<NotificationMessage> notifications)
        {
            if (!Enum.IsDefined(typeof(TradeType), trade.TradeType) || trade.TradeType == TradeType.Other)
            {
                notifications.Add(new NotificationMessage
                {
                    From = "Orders@cryptowallet.com",
                    To = "alert@cryptowallet.com",
                    Message = $"suspicious trade {trade.Description} @ {DateTime.UtcNow} UTC: Invalid Trade type",
                    MessageType = NotificationMessageType.Email,
                    Subject = "Suspicious trade: Invalid Trade type"
                });
            }
        }

        private void ValidateTradeAmount(Trade trade, List<NotificationMessage> notifications)
        {
            if (trade.Amount >= _appSettings.OrderAlertAmount)
            {
                notifications.Add(new NotificationMessage
                {
                    From = "Orders@cryptowallet.com",
                    To = "alert@cryptowallet.com",
                    Message = $"suspicious trade {trade.Description} @ {DateTime.UtcNow} UTC: Amount above threshold",
                    MessageType = NotificationMessageType.Email,
                    Subject = "Suspicious trade: Amount above threshold"
                });
            }
        }
    }
}
