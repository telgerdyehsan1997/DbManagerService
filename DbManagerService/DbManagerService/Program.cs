using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data.EF;
using Infrastructure.Identity;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DbManagerService
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var passwordHasher = services.GetRequiredService<IPasswordHasher>();

                try
                {
                    var mainModelContext = services.GetRequiredService<DMSContext>();
                    await DMSContextSeed.SeedAsync(mainModelContext, loggerFactory, passwordHasher, 10);


                    var userManager = services.GetRequiredService<UserManager<SystemUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await SystemIdentityContextSeed.SeedAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }

            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
