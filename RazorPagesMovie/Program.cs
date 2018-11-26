using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionVisitors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;

namespace RazorPagesMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
//            CreateWebHostBuilder(args).Build().Run();
            IWebHost host = BuildWebHost(args);

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                try
                {
                    MovieContext context = services.GetRequiredService<MovieContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(services);
                }
                catch (Exception exception)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred seeding the DB.");
                }
            }
            
            host.Run();
        }

        private static IWebHost BuildWebHost(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                      .UseStartup<Startup>()
                      .Build();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();
    }
}