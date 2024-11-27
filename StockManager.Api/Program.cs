using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // ASP.NET Core Web API - .NET Core 3.1
        // MVC (Model View Controller)
        // Model -> Everything related to back-end code, repository, services, entities, etc.
        // View -> Related to front-end, user interface.
        // Controller -> Implementation of the connection/communication between the Views and the Models.
        // Controller receive all requests from View and connect this with the Model.
        // App runs on localhost:port
        // folder Properties -> launchSettings.json (we can choose between 2 profiles to launch the application)
        // Slash -> / (barra)
    }
}
