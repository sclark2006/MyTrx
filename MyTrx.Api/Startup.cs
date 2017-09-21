using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyTrx.Data.Config;
using MyTrx.BusinessLogic.Config;
using MyTrx.Api.Config;
using Swashbuckle.AspNetCore.Swagger;
using MyTrx.Data.Contexts;

namespace MyTrx.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().AddControllersAsServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MyTrx Web Api", Version = "v1" });
            });

            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacDataModule(Configuration, services));
            builder.RegisterModule(new AutofacBLModule());
            builder.RegisterModule(new AutofacApiModule());

            builder.Populate(services);
           
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(builder.Build());
        }

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            MyTrxInitialData seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyTrx Web Api");
            });

            //Populate Initial Data
            try
            {
                seeder.SeedData().Wait();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
