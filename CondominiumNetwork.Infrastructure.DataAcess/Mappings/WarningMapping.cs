using CondominiumNetwork.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumNetwork.Infrastructure.DataAcess.Mappings
{
    public class WarningMapping : IEntityTypeConfiguration<Warning>
    {
        public void Configure(EntityTypeBuilder<Warning> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Content)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.ToTable("Warnings");
        }
    }
}
