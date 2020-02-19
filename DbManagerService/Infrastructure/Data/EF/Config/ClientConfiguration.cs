using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.EF.Config
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasIndex(b => b.Username)
                .IsUnique();

            builder.HasMany(b => b.AccessedRanges)
                .WithOne(b => b.client)
                .HasForeignKey(b => b.ClientId);

        }
    }
}
