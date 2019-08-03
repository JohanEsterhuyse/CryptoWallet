using System;

namespace CryptoWallet.Orders.Common.Interface.DAL
{
    public interface IRepository<T> where T : class
    {
        bool Create(T item);

        T Get(Guid id);

        bool Update(T item);

        bool Delete(Guid id);
    }
}
