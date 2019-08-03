using CryptoWallet.Identity.Common.Model;

namespace CryptoWallet.Identity.Helper
{
    public static class Utilities
    {
        public static CustomError GetError(int code, int httpCode, string message, string description)
        {
            CustomError error = new CustomError
            {
                Message = message,
                HttpCode = httpCode,
                Description = description,
                Code = code
            };
            return error;
        }
    }
}
