using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CondominiumNetwork.Infrastructure.DataAcess.Context
{
    public class CondominiumNetworkContext : IdentityDbContext<ApplicationUser>
    {
        private static bool _Created = false;
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Ocurrence> Ocurrences { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Warning> Warnings { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }


        public CondominiumNetworkContext(DbContextOptions<CondominiumNetworkContext> options) : base(options)
        {
            if (!_Created)
            {
                _Created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CondominiumNetworkContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
