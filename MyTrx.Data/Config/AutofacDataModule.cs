using Autofac;
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

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MyTrxContext(_connectionString)).As<IDbContext>();
            builder.RegisterType<GenericRepository>().As<IRepository>().InstancePerLifetimeScope();
        }
    }
}
