using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.Persistance.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectRepositoryURL> ProjectRepositoriesUrl { get; set; }
        public DbSet<UrlType> UrlTypes { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
        public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasNoKey();
        }

    }
}
