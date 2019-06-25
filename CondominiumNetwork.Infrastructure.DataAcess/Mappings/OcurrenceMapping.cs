using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumNetwork.Infrastructure.DataAcess.Mappings
{
    public class OcurrenceMapping : IEntityTypeConfiguration<Ocurrence>
    {
        public void Configure(EntityTypeBuilder<Ocurrence> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Content)
                .IsRequired()
                .HasColumnType("varchar(600)");

            // 1 : N => Ocorrence : Answer
            builder.HasMany(a => a.Answers)
                .WithOne(o => o.Ocurrence)
                .HasForeignKey(o => o.OcurrenceId);

            builder.Property(dbCategory => dbCategory.Category)
                .HasConversion(
                    category => category.ToString(),
                    category => new Category(category))
                .HasColumnName("Category");

            builder.ToTable("Ocurrences");
        }
    }
}
