using CryptoWallet.Orders.Domain;

namespace CryptoWallet.Orders.Service.Models
{
    public class TradeDto
    {
        public TradeType TradeType { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }
    }
}
