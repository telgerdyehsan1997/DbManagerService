using ApplicationCore.Entities;
using ApplicationCore.Enums;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF
{
    public class DMSContextSeed
    {
        private static IPasswordHasher _passwordHasher;

        public static async Task SeedAsync(DMSContext context,
            ILoggerFactory loggerFactory,
            IPasswordHasher passwordHasher,
            int? retry = 0)
        {

            _passwordHasher = passwordHasher;
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(GetPreconfiguredClients());
                    await context.SaveChangesAsync();
                }


                if (!context.Databases.Any())
                {
                    context.Databases.AddRange(GetPreconfiguredDatabases());
                    await context.SaveChangesAsync();
                }


                if (!context.EntityRecords.Any())
                {

                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability > 0)
                {
                    retryForAvailability--;
                    var log = loggerFactory.CreateLogger<DMSContext>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, passwordHasher, retryForAvailability);
                }
            }
        }



        static IEnumerable<Client> GetPreconfiguredClients()
        {
            return new List<Client>
            {
                new Client{
                    Username ="InitialClient",
                    HashedPassword =_passwordHasher.HashPassword("InitialClientPassword")
                }
            };
        }

        static IEnumerable<DatabaseItem> GetPreconfiguredDatabases()
        {
            return new List<DatabaseItem>
            {
                new DatabaseItem{
                    ConnectionString ="",
                    Status =DatabaseStatusEnum.Running
                }
            };
        }


    }
}
