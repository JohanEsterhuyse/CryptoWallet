namespace CryptoWallet.Orders.Domain.Model
{
    public enum TradeType
    {
        FundTransfer = 1,
        HomeMaintenance = 2,
        BillPayments = 3,
        Salary = 4,
        Bonus = 5,
        Commission = 6,
        Purchase = 7,
        InterBankTransfer = 8,
        Other = 9
    }
}
