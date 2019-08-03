using CryptoWallet.Identity.Common.Interface.DAL;
using CryptoWallet.Identity.Common.Model;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Threading.Tasks;

namespace CryptoWallet.Identity.Authorize
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IAuthRepository _authRepository;

        public ResourceOwnerPasswordValidator(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var task = _authRepository.ValidateUserAsync(context.UserName, context.Password);
            task.Wait();

            RootObject rootObject = task.Result;

            if (rootObject?.ValidateUser.Result == 0)
            {
                context.Result = new GrantValidationResult(rootObject.ValidateUser.UserID.ToString(), "password", null, "local", null);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The user or password are incorrect", null);
            }

            return Task.FromResult(context.Result);
        }
    }
}
