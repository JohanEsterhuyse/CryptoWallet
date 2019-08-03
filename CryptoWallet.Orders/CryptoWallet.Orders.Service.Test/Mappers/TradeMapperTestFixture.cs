using CryptoWallet.Orders.Domain;
using CryptoWallet.Orders.Service.Mappers;
using CryptoWallet.Orders.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CryptoWallet.Orders.Service.Test.Mappers
{
    public class TradeMapperTestFixture
    {
        [Fact]
        public void DtoToModel_GivenValidTradeDto_ValidTradeReturned()
        {
            //Arrange
            var tradeDto = new TradeDto()
            {
                Amount = 1000,
                Description = "Test",
                TradeType = TradeType.Bonus
            };

            //Act
            var result = TradeMapper.DtoToModel(tradeDto);

            //Assert
            Assert.Equal(tradeDto.Amount, result.Amount);
            Assert.Equal(tradeDto.Description, result.Description);
            Assert.Equal(tradeDto.TradeType, result.TradeType);
        }
    }
}
