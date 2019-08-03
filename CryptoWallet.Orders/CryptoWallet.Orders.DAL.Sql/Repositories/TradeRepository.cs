using CryptoWallet.Orders.Common.Interface.DAL;
using CryptoWallet.Orders.Domain.Model;
using CryptoWallet.Orders.Service;
using System;
using System.Linq;

namespace CryptoWallet.Orders.DAL.Sql.Repositories
{
    public class TradeRepository : IRepository<Trade>
    {
        private readonly OrderContext _orderContext;

        public TradeRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public bool Create(Trade item)
        {
            _orderContext.Trades.Add(item);
            var effected = _orderContext.SaveChanges();

            return effected > 0;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Trade Get(Guid id)
        {
            return _orderContext.Trades.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Update(Trade item)
        {
            _orderContext.Trades.Update(item);
            var effected = _orderContext.SaveChanges();

            return effected > 0;
        }
    }
}
