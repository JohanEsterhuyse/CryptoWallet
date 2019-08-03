using CryptoWallet.Identity.Common.Interface.DAL;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CryptoWallet.Identity.Authorize
{
    public class ProfileService : IProfileService
    {
        private IAuthRepository _authRepository;

        public ProfileService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userID = context.Subject.Claims.FirstOrDefault().Value;
            var credentials = _authRepository.GetUserCredentials(userID);

            context.IssuedClaims = new List<Claim>
                     {
                           //This is the list of claims that we are going to add to the JWT Token
                            new Claim(JwtClaimTypes.Role, "Role1"),
                            new Claim(JwtClaimTypes.Role, "Role 2")
                     };

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            //Todo: check if the user is active
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}
