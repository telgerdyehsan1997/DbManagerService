using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ApplicationCore.Entities;

namespace Infrastructure.Data.EF
{
    public class DMSContext:DbContext
    {
        public DMSContext(DbContextOptions<DMSContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<DatabaseItem> Databases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EntityRecord> EntityRecords { get; set; }

    }
}
