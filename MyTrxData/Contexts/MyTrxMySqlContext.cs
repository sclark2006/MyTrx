using Microsoft.EntityFrameworkCore;
///using MySQL.Data.EntityFrameworkCore.Extensions;
using MyTrx.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrx.Data.Contexts
{
    public class MyTrxContext : DbContext
    {
        public MyTrxContext(DbContextOptions<MyTrxContext> options)
        : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
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
