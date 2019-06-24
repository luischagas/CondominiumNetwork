using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominiumNetwork.WebApp.ViewModels;

namespace CondominiumNetwork.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CondominiumNetwork.WebApp.ViewModels.ProfileViewModel> ProfileViewModel { get; set; }
        public DbSet<CondominiumNetwork.WebApp.ViewModels.AnswerViewModel> AnswerViewModel { get; set; }
        public DbSet<CondominiumNetwork.WebApp.ViewModels.WarningViewModel> WarningViewModel { get; set; }
    }
}
