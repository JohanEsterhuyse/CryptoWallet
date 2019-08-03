using CryptoWallet.Identity.Common.Model;
using System.Threading.Tasks;

namespace CryptoWallet.Identity.Common.Interface.DAL
{
    public interface IAuthRepository
    {
        Task<RootObject> ValidateUserAsync(string username, string password);
        Task<string> GetUserCredentials(string username);
    }
}
