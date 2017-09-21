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
        private readonly IConfiguration _configuration;
        public AutofacDataModule(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            var contextFactory = new MyTrxContextFactory();
            services.AddDbContext<MyTrxContext>(options => contextFactory.ConfigureOptions(options, configuration));
            services.AddTransient<MyTrxInitialData>();
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyTrxContext>().As<IMyTrxContext>();
            builder.RegisterType<GenericRepository>().As<IRepository>().InstancePerLifetimeScope();
        }
    }
}
