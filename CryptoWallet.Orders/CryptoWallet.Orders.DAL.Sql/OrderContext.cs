using CryptoWallet.Notification.Common.Interface.Common;
using CryptoWallet.Orders.Domain;
using Microsoft.EntityFrameworkCore;

namespace CryptoWallet.Orders.Service
{
    public class OrderContext : DbContext
    {
        private readonly IAppSettings _appSettings;

        public OrderContext(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public DbSet<Trade> Trades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_appSettings.ConnectionString);
        }
    }
}
