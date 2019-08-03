using Microsoft.AspNetCore.Http;

namespace CryptoWallet.Identity.Authorize
{
    public static class ErrorExtension
    {
        public static void AddApplicationError(this HttpResponse response, string error)
        {
            response.Headers.Add("Application-Error", error);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error"); 
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
