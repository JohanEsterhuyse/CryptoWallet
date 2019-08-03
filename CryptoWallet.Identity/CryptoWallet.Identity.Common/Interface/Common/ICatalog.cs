using Microsoft.Extensions.DependencyInjection;

namespace CryptoWallet.Identity.Common.Interface.Common
{
    public interface ICatalog
    {
        void RegisterServices(ServiceCollection serviceCollection);
    }
}
