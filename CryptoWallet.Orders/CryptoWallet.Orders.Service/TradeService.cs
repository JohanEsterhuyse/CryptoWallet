using CryptoWallet.Orders.Common.Interface.DAL;
using CryptoWallet.Orders.Domain;
using CryptoWallet.Orders.Service.Mappers;
using CryptoWallet.Orders.Service.Models;

namespace CryptoWallet.Orders.Service
{
    public class TradeService
    {
        private readonly IRepository<Trade> _tradeRepository;

        public TradeService(IRepository<Trade> tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public bool CreateTrade(TradeDto tradeDto)
        {
            var trade = TradeMapper.DtoToModel(tradeDto);

            return _tradeRepository.Create(trade);
        }
    }
}
