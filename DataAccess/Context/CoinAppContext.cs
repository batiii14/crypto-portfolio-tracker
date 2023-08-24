using Entities.concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class CoinAppContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CoinDbApp;Trusted_Connection=true");
        }


        public DbSet<BuyingTransaction> BuyingTransactions { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<SellingTransaction> SellingTransactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<CoinUpdater> CoinUpdaters { get; set; }
        public DbSet<CoinsBought> coinsBoughts { get; set; }
    }
}
