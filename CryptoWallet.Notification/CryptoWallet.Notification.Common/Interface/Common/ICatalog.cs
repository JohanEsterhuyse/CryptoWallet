using Microsoft.Extensions.DependencyInjection;

namespace CryptoWallet.Notification.Common.Interface.Common
{
    public interface ICatalog
    {
        void RegisterServices(ServiceCollection serviceCollection);
    }
}
