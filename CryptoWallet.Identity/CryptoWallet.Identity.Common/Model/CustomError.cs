namespace CryptoWallet.Identity.Common.Model
{
    public class CustomError
    {
        public int Code { get; set; }

        public int HttpCode { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }
    }
}
