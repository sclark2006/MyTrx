using Autofac;
using MyTrx.BusinessLogic.Services;
using MyTrx.Data.Repositories;

namespace MyTrx.BusinessLogic.Config
{
    public class AutofacBLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransactionsQueryService>().As<ITransactionsQueryService>();            
        }
    }
}
