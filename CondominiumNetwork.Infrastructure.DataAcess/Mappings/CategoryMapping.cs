using CondominiumNetwork.DomainModel.ValueObjects;
using CondominiumNetwork.Infrastructure.DataAcess.Context.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominiumNetwork.Infrastructure.DataAcess.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<DbCategory>
    {
        public void Configure(EntityTypeBuilder<DbCategory> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(dbCategory => dbCategory.Category)
               .HasConversion(
                   category => category.ToString(),
                   category => new Category(category))
               .HasColumnName("Description");

            builder.ToTable("Category");
        }
    }
}
