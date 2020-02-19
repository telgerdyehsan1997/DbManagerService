using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.EF.Config
{
    public class DatabaseItemConfiguration : IEntityTypeConfiguration<DatabaseItem>
    {
        public void Configure(EntityTypeBuilder<DatabaseItem> builder)
        {
            builder.HasMany(b => b.ContainedRanges)
                .WithOne(b => b.database)
                .HasForeignKey(b => b.DbId);
        }
    }
}
