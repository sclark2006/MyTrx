using Autofac;
using Microsoft.EntityFrameworkCore;
//using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTrx.Data.Contexts;
using MyTrx.Data.Repositories;

namespace MyTrx.Data.Config
{
    public class AutofacDataModule : Module
    {
        private readonly string _connectionString;

        public AutofacDataModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AutofacDataModule(IConfigurationRoot configuration, IServiceCollection services)
        {
            services.AddDbContext<MyTrxContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyTrxContext>().As<IMyTrxContext>();
            builder.RegisterType<GenericRepository>().As<IRepository>().InstancePerLifetimeScope();
        }
    }
}
