using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.WebAPI.Database;
using eTransport.WebAPI.Database.DB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace eTransport.WebAPI
{
    public class Program
    {
        public static void Main(string[] args) //async Task
        {
            //var host = CreateHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<eTransportContext>();
            //        var userManager = services.GetRequiredService<UserManager<User>>();
            //        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();

            //        DbInitializer.Seed(context, userManager, roleManager).Wait();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occured while seeding the database.");
            //    }
            //}
            //await host.RunAsync();

            var hosts = CreateHostBuilder(args).Build();
            using (var scope = hosts.Services.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<eTransportContext>();
                service.Database.Migrate();
            }
            hosts.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
