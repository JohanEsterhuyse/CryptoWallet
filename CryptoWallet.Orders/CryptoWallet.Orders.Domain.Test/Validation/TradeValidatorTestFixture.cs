using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Orders.Domain.Model;
using CryptoWallet.Orders.Domain.Validation;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace CryptoWallet.Orders.Domain.Test.Validation
{
    public class TradeValidatorTestFixture
    {
        [Fact]
        public void Validate_GivenTradeBelowSuspiciousAmount_ReturnsEmptyNotificationList()
        {
            //Arrange
            var trade = new Trade()
            {
                Amount = 100,
                Description = "Test Description",
                TradeType = TradeType.BillPayments
            };

            var configuration = new Mock<IAppSettings>();
            configuration.Setup(x => x.OrderAlertAmount).Returns(10000);

            var tradeValidator = new TradeValidator(configuration.Object);

            //Act
            var result = tradeValidator.Validate(trade);

            //Assert
            Assert.Empty(result);
            configuration.Verify(x => x.OrderAlertAmount, Times.Once);
        }

        [Fact]
        public void Validate_GivenTradeAboveSuspiciousAmount_ReturnsNotificationListWithSuspiciousAlert()
        {
            //Arrange
            var trade = new Trade()
            {
                Amount = 15000,
                Description = "Test Description",
                TradeType = TradeType.BillPayments
            };

            var configuration = new Mock<IAppSettings>();
            configuration.Setup(x => x.OrderAlertAmount).Returns(10000);

            var tradeValidator = new TradeValidator(configuration.Object);

            //Act
            var result = tradeValidator.Validate(trade);

            //Assert
            Assert.Single(result);
            Assert.Equal("Suspicious trade: Amount above threshold", result.First().Subject);
            
            configuration.Verify(x => x.OrderAlertAmount, Times.Once);
        }

        [Fact]
        public void Validate_GivenTradeEqualToSuspiciousAmount_ReturnsNotificationListWithSuspiciousAlert()
        {
            //Arrange
            var trade = new Trade()
            {
                Amount = 10000,
                Description = "Test Description",
                TradeType = TradeType.BillPayments
            };

            var configuration = new Mock<IAppSettings>();
            configuration.Setup(x => x.OrderAlertAmount).Returns(10000);

            var tradeValidator = new TradeValidator(configuration.Object);

            //Act
            var result = tradeValidator.Validate(trade);

            //Assert
            Assert.Single(result);
            Assert.Equal("Suspicious trade: Amount above threshold", result.First().Subject);

            configuration.Verify(x => x.OrderAlertAmount, Times.Once);
        }

        [Theory]
        [InlineData(TradeType.BillPayments)]
        [InlineData(TradeType.Bonus)]
        [InlineData(TradeType.Commission)]
        [InlineData(TradeType.FundTransfer)]
        [InlineData(TradeType.HomeMaintenance)]
        [InlineData(TradeType.InterBankTransfer)]
        //[InlineData(TradeType.Other)]
        [InlineData(TradeType.Purchase)]
        [InlineData(TradeType.Salary)]
        public void Validate_GivenValidTradeType_ReturnsEmptyNotificationList(TradeType tradeType)
        {
            //Arrange
            var trade = new Trade()
            {
                Amount = 100,
                Description = "Test Description",
                TradeType = tradeType
            };

            var configuration = new Mock<IAppSettings>();
            configuration.Setup(x => x.OrderAlertAmount).Returns(10000);

            var tradeValidator = new TradeValidator(configuration.Object);

            //Act
            var result = tradeValidator.Validate(trade);

            //Assert
            Assert.Empty(result);
            configuration.Verify(x => x.OrderAlertAmount, Times.Once);
        }

        [Theory]
        [InlineData(TradeType.Other)]
        public void Validate_GivenInvalidTradeTypeAmount_ReturnsNotificationListWithSuspiciousAlert(TradeType tradeType)
        {
            //Arrange
            var trade = new Trade()
            {
                Amount = 100,
                Description = "Test Description",
                TradeType = tradeType
            };

            var configuration = new Mock<IAppSettings>();
            configuration.Setup(x => x.OrderAlertAmount).Returns(10000);

            var tradeValidator = new TradeValidator(configuration.Object);

            //Act
            var result = tradeValidator.Validate(trade);

            //Assert
            Assert.Single(result);
            Assert.Equal("Suspicious trade: Invalid Trade type", result.First().Subject);

            configuration.Verify(x => x.OrderAlertAmount, Times.Once);
        }

        [Fact]
        public void Validate_GivenNullTradeTypeAmount_ReturnsNotificationListWithSuspiciousAlert()
        {
            //Arrange
            var trade = new Trade()
            {
                Amount = 100,
                Description = "Test Description"
            };

            var configuration = new Mock<IAppSettings>();
            configuration.Setup(x => x.OrderAlertAmount).Returns(10000);

            var tradeValidator = new TradeValidator(configuration.Object);

            //Act
            var result = tradeValidator.Validate(trade);

            //Assert
            Assert.Single(result);
            Assert.Equal("Suspicious trade: Invalid Trade type", result.First().Subject);

            configuration.Verify(x => x.OrderAlertAmount, Times.Once);
        }
    }
}
