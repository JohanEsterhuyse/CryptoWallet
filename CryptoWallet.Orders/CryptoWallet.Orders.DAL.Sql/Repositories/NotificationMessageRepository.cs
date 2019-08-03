using CryptoWallet.Orders.Common.Interface.DAL;
using CryptoWallet.Orders.Domain.Model;
using CryptoWallet.Orders.Service;
using System;

namespace CryptoWallet.Orders.DAL.Sql.Repositories
{
    public class NotificationMessageRepository : IRepository<NotificationMessage>
    {
        private readonly OrderContext _orderContext;

        public NotificationMessageRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public bool Create(NotificationMessage item)
        {
            _orderContext.NotificationMessages.Add(item);
            var effected = _orderContext.SaveChanges();

            return effected > 0;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public NotificationMessage Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(NotificationMessage item)
        {
            _orderContext.NotificationMessages.Update(item);
            var effected = _orderContext.SaveChanges();

            return effected > 0;
        }
    }
}
