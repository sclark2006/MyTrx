using Autofac;
using MyTrx.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrx.Api.Config
{
    public class AutofacApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            builder.Register(c => new TransactionsQueryService())
                .As<ITransactionsQueryService>()
                .InstancePerLifetimeScope();
        }
    }
}
