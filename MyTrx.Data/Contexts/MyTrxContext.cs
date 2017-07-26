using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
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
        public readonly string _connectionString;
        
        public MyTrxContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    //public static class MyTrxContextFactory
    //{
    //    public static MyTrxContext Create(string connectionString)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<MyTrxContext>();
    //        optionsBuilder.UseMySQL(connectionString);

    //        //Ensure database creation
    //        var context = new MyTrxContext(optionsBuilder.Options);
    //        context.Database.EnsureCreated();

    //        return context;
    //    }
    //}
}
