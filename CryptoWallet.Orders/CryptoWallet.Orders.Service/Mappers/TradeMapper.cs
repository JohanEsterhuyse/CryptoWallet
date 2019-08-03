using CryptoWallet.Orders.Domain;
using CryptoWallet.Orders.Service.Models;

namespace CryptoWallet.Orders.Service.Mappers
{
    public static class TradeMapper
    {
        public static Trade DtoToModel(TradeDto tradeDto)
        {
            return new Trade()
            {
                TradeType = tradeDto.TradeType,
                Description = tradeDto.Description,
                Amount = tradeDto.Amount
            };
        }
    }
}
