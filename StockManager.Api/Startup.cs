using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockManager.Api.Infrastructure.Application;
using StockManager.Api.Infrastructure.Contexts;
using StockManager.Api.Infrastructure.Repositories;
using StockManager.Api.Infrastructure.Services;
using StockManager.Api.Models.Interfaces.Application;
using StockManager.Api.Models.Interfaces.Repositories;
using StockManager.Api.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Dependency Injection configuration
            // Setting it up as Singleton, we change the behavior of the class SimpleDatabase injected on the controller class,
            // this way our SimpleDatabase object will just be instantiated once and it's gonna be same object till we stop running
            // our application. When we start running the application the object will be created at some point and the same object is
            // gonna be used till we stop running our application, we won't be instantiating a new object on each request as it was 
            // happening before this setting as Singleton.
            // This is one of the three possible configurations for life cycle of objects by Dependency Injection we have.
            services.AddSingleton<SimpleDatabase>();

            // Setting the configuration for the repository class that implements the interface, we need to configure the DI for this
            // class, our repository class, because this class will be used as an object and will be injected in other classes.
            // The order for setting that up is interface, class that implements that interface.
            services.AddScoped<ProductRepository, ProductRepositoryImpl>();

            // Configuring the Dependency Injection and life cycle of the Service object.
            services.AddScoped<ProductService, ProductServiceImpl>();

            services.AddScoped<ProductApplication, ProductApplicationImpl>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
