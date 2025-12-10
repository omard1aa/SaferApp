using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Safer.Services.Identity.Domain.Models;

namespace Safer.Services.Identity.Infrastructure.Persistence;

public class IdentityServiceDbContext : IdentityDbContext<User>
{
    public IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Mentorship Note:
        // Always call base.OnModelCreating(builder) when using IdentityDbContext.
        // It configures all the Identity tables (AspNetUsers, AspNetRoles, etc.) for you.
        
        // You can add custom configurations here, e.g.:
        // builder.Entity<User>().ToTable("Users"); // If you want to rename the table
    }
}
