using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Orders.Common.Interface.DAL;
using CryptoWallet.Orders.Domain;
using CryptoWallet.Orders.Domain.Model;
using CryptoWallet.Orders.Domain.Validation;
using CryptoWallet.Orders.Service.Helper;
using CryptoWallet.Orders.Service.Models;
using Moq;
using Xunit;

namespace CryptoWallet.Orders.Service.Test
{
    public class TradeServiceTestFixture
    {
        [Fact]
        public void CreateTrade_GivenValidTradeDtoProvidedAndTradeValid_TradeRepositoryCalledOnce()
        {
            //Arrange
            var tradeDto = new TradeDto()
            {
                Amount = 100,
                Description = "Test Description",
                TradeType = TradeType.BillPayments
            };

            Trade callbackTrade = null;

            var tradeRepository = new Mock<IRepository<Trade>>();

            tradeRepository
                .Setup(x => x.Create(It.IsAny<Trade>()))
                .Returns(true)
                .Callback<Trade>((t) => callbackTrade = t);

            var notificationMessageRepository = new Mock<IRepository<NotificationMessage>>();

            var notificationHelper = new Mock<INotificationHelper>();

            var appSettings = new Mock<IAppSettings>();
            appSettings.Setup(x => x.OrderAlertAmount).Returns(1000);

            var tradeValidator = new TradeValidator(appSettings.Object);

            var tradeService = new TradeService(tradeRepository.Object,
                notificationMessageRepository.Object,
                tradeValidator,
                notificationHelper.Object);

            //Act
            var result = tradeService.CreateTrade(tradeDto);

            //Assert
            tradeRepository.Verify(x => x.Create(It.IsAny<Trade>()), Times.Once);
            notificationMessageRepository.Verify(x => x.Create(It.IsAny<NotificationMessage>()), Times.Never);
            notificationHelper.Verify(x => x.SendNotificationMessage(It.IsAny<NotificationMessage>()), Times.Never);

            Assert.Equal(tradeDto.Amount, callbackTrade.Amount);
            Assert.Equal(tradeDto.Description, callbackTrade.Description);
            Assert.Equal(tradeDto.TradeType, callbackTrade.TradeType);

            Assert.True(result);
        }

        [Fact]
        public void CreateTrade_GivenValidTradeDtoProvidedAndTradeInValid_AllRepositoryCalledOnce()
        {
            //Arrange
            var tradeDto = new TradeDto()
            {
                Amount = 1000000,
                Description = "Test Description",
                TradeType = TradeType.BillPayments
            };

            Trade callbackTrade = null;

            var tradeRepository = new Mock<IRepository<Trade>>();

            tradeRepository
                .Setup(x => x.Create(It.IsAny<Trade>()))
                .Returns(true)
                .Callback<Trade>((t) => callbackTrade = t);

            var notificationMessageRepository = new Mock<IRepository<NotificationMessage>>();

            notificationMessageRepository
                .Setup(x => x.Create(It.IsAny<NotificationMessage>()))
                .Returns(true);

            var notificationHelper = new Mock<INotificationHelper>();

            var appSettings = new Mock<IAppSettings>();
            appSettings.Setup(x => x.OrderAlertAmount).Returns(1000);

            var tradeValidator = new TradeValidator(appSettings.Object);

            var tradeService = new TradeService(tradeRepository.Object,
                notificationMessageRepository.Object,
                tradeValidator,
                notificationHelper.Object);

            //Act
            var result = tradeService.CreateTrade(tradeDto);

            //Assert
            tradeRepository.Verify(x => x.Create(It.IsAny<Trade>()), Times.Once);
            notificationMessageRepository.Verify(x => x.Create(It.IsAny<NotificationMessage>()), Times.Once);
            notificationHelper.Verify(x => x.SendNotificationMessage(It.IsAny<NotificationMessage>()), Times.Once);

            Assert.Equal(tradeDto.Amount, callbackTrade.Amount);
            Assert.Equal(tradeDto.Description, callbackTrade.Description);
            Assert.Equal(tradeDto.TradeType, callbackTrade.TradeType);

            Assert.True(result);
        }
    }
}
