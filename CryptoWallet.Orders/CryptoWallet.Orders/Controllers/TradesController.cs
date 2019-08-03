using CryptoWallet.Orders.Service;
using CryptoWallet.Orders.Service.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost]
        [Route("createtrade")]
        public bool CreateTrade([FromBody] TradeDto tradeDto)
        {
            return _tradeService.CreateTrade(tradeDto);
        }
    }
}
