using System;

namespace CryptoWallet.Orders.Domain
{
    public class Trade
    {
        Guid Id { get; set; }

        TradeType TradeType { get; set; }

        string Description { get; set; }

        decimal Amount { get; set; }
    }
}
