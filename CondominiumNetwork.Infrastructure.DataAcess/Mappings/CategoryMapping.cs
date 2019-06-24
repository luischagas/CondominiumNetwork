using CondominiumNetwork.Infrastructure.DataAcess.Context.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumNetwork.Infrastructure.DataAcess.Mappings
{
   public class CategoryMapping : IEntityTypeConfiguration<DbCategory>
    {
        public void Configure(EntityTypeBuilder<DbCategory> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Category)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Categories");
        }
    }
}
