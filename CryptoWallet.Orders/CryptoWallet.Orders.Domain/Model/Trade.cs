using System;

namespace CryptoWallet.Orders.Domain.Model
{
    public class Trade
    {
        public Guid Id { get; set; }

        public TradeType TradeType { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        bool Suspicious { get; set; }
    }
}
