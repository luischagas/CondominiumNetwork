using CondominiumNetwork.DomainModel.ValueObjects;
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

            builder.Property(dbCategory => dbCategory.Category)
                .HasConversion(
                    category => category.ToString(),
                    category => new Category(category))
                .HasColumnName("Category");

            builder.ToTable("Categories");
        }
    }
}
