using Autofac;
using MyTrx.BusinessLogic.Services;
using MyTrx.Data.Repositories;

namespace MyTrx.BusinessLogic.Config
{
    public class AutofacBLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            builder.RegisterType<TransactionsQueryService>().As<ITransactionsQueryService>();
            
        }
    }
}
