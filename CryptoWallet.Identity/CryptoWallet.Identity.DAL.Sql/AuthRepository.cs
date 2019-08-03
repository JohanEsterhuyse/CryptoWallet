using CryptoWallet.Identity.Common.Interface.DAL;
using CryptoWallet.Identity.Common.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoWallet.Identity.DAL.Sql
{
    public class AuthRepository : IAuthRepository
    {
        static HttpClient client = new HttpClient();

        readonly string TswCustomEntpoint = "http";

        readonly string TswProxyEntpoint = "http://10.2.180.10:8086/api/tswuser&#8221";

        public async Task<string> GetUserCredentials(string username)
        {
            return "";
            // Return the string with the credentiasl  
        }
        public async Task<RootObject> ValidateUserAsync(string username, string password)
        {
            return new RootObject();
            // Returns the user information.
        }
    }
}
