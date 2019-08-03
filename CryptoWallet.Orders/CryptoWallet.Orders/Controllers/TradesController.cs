using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoWallet.Orders.Service;
using CryptoWallet.Orders.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWallet.Orders.Controllers
{
    [Route("api/trades")]
    public class TradesController : Controller
    {
        private readonly TradeService _tradeService;

        public TradesController(TradeService tradeService)
        {
            _tradeService = tradeService;
        }

        // GET api/values
        [HttpPost]
        [Route("createtrade")]
        public bool CreateTrade([FromBody] TradeDto tradeDto)
        {
            return _tradeService.CreateTrade(tradeDto);
        }
    }
}
