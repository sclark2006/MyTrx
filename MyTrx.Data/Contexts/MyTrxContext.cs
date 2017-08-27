using Microsoft.EntityFrameworkCore;
using MyTrx.Data.Entities;

namespace MyTrx.Data.Contexts
{
    public interface IMyTrxContext : IDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
    public class MyTrxContext : DbContext, IMyTrxContext
    {
        public MyTrxContext(DbContextOptions<MyTrxContext> options)
        :base(options)
        {
        }
 
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }

}
