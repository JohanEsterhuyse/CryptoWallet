using CryptoWallet.Notification.Common.Interface.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoWallet.Notification.Common.DependencyInjection
{
    public static class CatelogExtention
    {
        public static void RegisterModule<T>(this ServiceCollection service) where T : ICatalog, new()
        {
            var module = new T();
            module.RegisterServices(service);
        }
    }
}
