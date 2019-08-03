using CryptoWallet.Orders.Common.Interface.DAL;
using CryptoWallet.Orders.Domain;
using CryptoWallet.Orders.Service.Models;
using Moq;
using Xunit;

namespace CryptoWallet.Orders.Service.Test
{
    public class TradeServiceTestFixture
    {
        [Fact]
        public void CreateTrade_GivenValidTradeDtoProvided_TradeRepositoryCalledOnce()
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

            var tradeService = new TradeService(tradeRepository.Object);

            //Act
            var result = tradeService.CreateTrade(tradeDto);

            //Assert
            tradeRepository.Verify(x => x.Create(It.IsAny<Trade>()), Times.Once);

            Assert.Equal(tradeDto.Amount, callbackTrade.Amount);
            Assert.Equal(tradeDto.Description, callbackTrade.Description);
            Assert.Equal(tradeDto.TradeType, callbackTrade.TradeType);

            Assert.True(result);
        }
    }
}
