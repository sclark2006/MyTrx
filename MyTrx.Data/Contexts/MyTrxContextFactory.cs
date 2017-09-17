using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrx.Data.Contexts
{
    public class MyTrxContextFactory : IDesignTimeDbContextFactory<MyTrxContext>
    {
        public MyTrxContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyTrxContext>();
            builder.UseSqlServer("server=localhost;database=mytrx;Integrated Security=True;MultipleActiveResultSets=true");
            return new MyTrxContext(builder.Options);
        }
    }
}
