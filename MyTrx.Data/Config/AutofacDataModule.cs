using Autofac;
using MyTrx.Data.Repositories;

namespace MyTrx.Data.Config
{
    public class AutofacDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            //.RegisterType<TransactionsQueryService>().As<ITransactionsQueryService>();
            builder.Register(c => new GenericRepository(null))
                .As<IRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
