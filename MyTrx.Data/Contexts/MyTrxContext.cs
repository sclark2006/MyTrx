using Microsoft.EntityFrameworkCore;
using MyTrx.Data.Entities;

namespace MyTrx.Data.Contexts
{
    public interface IMyTrxContext : IDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Payee> Payees { get; set; }

    }
    public class MyTrxContext : DbContext, IMyTrxContext
    {
        public MyTrxContext(DbContextOptions options)
        :base(options)
        {
        }
 
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payee> Payees { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

}
