using CondominiumNetwork.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumNetwork.Infrastructure.DataAcess.Mappings
{
    public class ProfileMapping : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.BlockApartment)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.PhotoUrl)
                .HasColumnType("varchar(100)");

            // 1 : N => Profile : Ocurrence
            builder.HasMany(p => p.Ocurrences)
                .WithOne(o => o.Profile)
                .HasForeignKey(o => o.ProfileId);

            // 1 : N => Profile : Answer
            builder.HasMany(p => p.Answers)
                .WithOne(a => a.Profile)
                .HasForeignKey(a => a.ProfileId);

            // 1 : N => Profile : Warning
            builder.HasMany(p => p.Warnings)
                .WithOne(w => w.Profile)
                .HasForeignKey(w => w.ProfileId);

            builder.ToTable("Profiles");
        }
    }
}
