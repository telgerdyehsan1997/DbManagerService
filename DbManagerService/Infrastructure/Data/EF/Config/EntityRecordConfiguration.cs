using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.EF.Config
{
    public class EntityRecordConfiguration : IEntityTypeConfiguration<EntityRecord>
    {
        public void Configure(EntityTypeBuilder<EntityRecord> builder)
        {
            builder.HasIndex(b => b.StartRange)
                .IsUnique();
            builder.HasIndex(b => b.EndRange)
                .IsUnique();

            builder.HasOne(b => b.client)
                .WithMany(b => b.AccessedRanges)
                .HasForeignKey(b => b.ClientId);

            builder.HasOne(b => b.database)
                .WithMany(b => b.ContainedRanges)
                .HasForeignKey(b => b.DbId);

        }
    }
}
