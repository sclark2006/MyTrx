using Microsoft.EntityFrameworkCore;
using MyTrx.Data.Entities;

namespace MyTrx.Data.Contexts
{
    public interface IMyTrxContext : IDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Category> Categories { get; set; }

    }
    public class MyTrxContext : DbContext, IMyTrxContext
    {
        public MyTrxContext(DbContextOptions<MyTrxContext> options)
        :base(options)
        {
        }
 
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            //GenerateIdForNewEntities();
            //CreateAuditLogInformation();
            //ModifyAuditInformation();
            //VerifyShardUpdateEntitiesIntegrity();
            //SetIdentifierEventSequence();
            return base.SaveChanges();
        }

        //public void CreateAuditLogInformation()
        //{
        //    foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().Where(x => x.State == EntityState.Added))
        //    {
        //        _setCreateAuditLogInformation.SetCreateAuditLog(entry.Entity);
        //    }
        //}
    }

}
