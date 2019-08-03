using CryptoWallet.Orders.Common.Interface.DAL;
using CryptoWallet.Orders.Domain;
using CryptoWallet.Orders.Domain.Model;
using CryptoWallet.Orders.Domain.Validation;
using CryptoWallet.Orders.Service.Helper;
using CryptoWallet.Orders.Service.Mappers;
using CryptoWallet.Orders.Service.Models;

namespace CryptoWallet.Orders.Service
{
    public class TradeService
    {
        private readonly IRepository<Trade> _tradeRepository;
        private readonly IRepository<NotificationMessage> _notificationMessageRepository;
        private readonly TradeValidator _tradeValidator;
        private readonly INotificationHelper _notificationHelper;
        
        public TradeService(IRepository<Trade> tradeRepository,
            IRepository<NotificationMessage> notificationMessageRepository,
            TradeValidator tradeValidator,
            INotificationHelper notificationHelper)
        {
            _tradeRepository = tradeRepository;
            _notificationMessageRepository = notificationMessageRepository;
            _tradeValidator = tradeValidator;
            _notificationHelper = notificationHelper;
        }

        public bool CreateTrade(TradeDto tradeDto)
        {
            var trade = TradeMapper.DtoToModel(tradeDto);

            var tradeNotifications = _tradeValidator.Validate(trade);

            foreach(var tradeNotification in tradeNotifications)
            {
                _notificationHelper.SendNotificationMessage(tradeNotification);
                _notificationMessageRepository.Create(tradeNotification);
            }

            return _tradeRepository.Create(trade);
        }
    }
}
