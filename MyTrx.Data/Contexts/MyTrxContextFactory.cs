using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyTrx.Data.Contexts
{
    public class MyTrxContextFactory : IDesignTimeDbContextFactory<MyTrxContext>
    {
        public MyTrxContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Config/appsettings.json")
            .Build();

            return CreateDbContext(configuration);
        }

        public MyTrxContext CreateDbContext(IConfiguration configuration)
        {
            var builder = new DbContextOptionsBuilder();
            builder = ConfigureOptions(builder, configuration);
            return new MyTrxContext(builder.Options);
        }

        public DbContextOptionsBuilder ConfigureOptions(DbContextOptionsBuilder builder, IConfiguration configuration)
        {
            var connType = configuration.GetConnectionString("ConnectionType");
            var connectionString = configuration.GetConnectionString(connType);

            builder = connType.ToLower().StartsWith("mysql")
                ? builder.UseMySQL(connectionString)
                : builder.UseSqlServer(connectionString);
            return builder;
        }
    }
}
