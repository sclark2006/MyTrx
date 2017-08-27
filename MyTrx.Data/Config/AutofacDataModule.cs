using Autofac;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTrx.Data.Contexts;
using MyTrx.Data.Repositories;
using System.Collections.Generic;
using System;

namespace MyTrx.Data.Config
{
    public class AutofacDataModule : Module
    {

        public AutofacDataModule(IConfigurationRoot configuration, IServiceCollection services)
        {
            var connType = configuration.GetConnectionString("ConnectionType");
            var connectionString = configuration.GetConnectionString(connType);

            services.AddDbContext<MyTrxContext>(options =>  ConfigureDbContext(options, connType, connectionString));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyTrxContext>().As<IMyTrxContext>();
            builder.RegisterType<GenericRepository>().As<IRepository>().InstancePerLifetimeScope();
        }

        private DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder options, string connType, string connectionString)
        {
            if(connType.ToLower().StartsWith("mysql"))
            {
                return options.UseMySQL(connectionString);
            }
            else
            {
                return options.UseSqlServer(connectionString);
            }

        }
    }
}
