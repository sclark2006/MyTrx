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
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            //services.AddCors(options =>
            //    options.AddPolicy("AllowAllOrigins", policyBuilder => { policyBuilder.AllowAnyOrigin(); }
            //    ));
            // Add framework services.
            services.AddMvc().AddControllersAsServices();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MyTrx Web Api", Version = "v1" });
            });

            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacDataModule(Configuration, services));
            builder.RegisterModule(new AutofacBLModule());
            builder.RegisterModule(new AutofacApiModule());

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            MyTrxInitialData seeder
            )
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //app.UseCors("AllowAllOrigins");
            app.UseCors(builder => builder.WithOrigins("http://localhost:57107/")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
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
