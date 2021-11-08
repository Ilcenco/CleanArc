using Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Application.Common.Interfaces
{
    public interface IDataContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectRepositoryURL> ProjectRepositoriesUrl { get; set; }
        DbSet<UrlType> UrlTypes { get; set; }
        DbSet<IdentityUser> IdentityUsers { get; set; }
        DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
        DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }
        DbSet<IdentityRole> IdentityRoles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
