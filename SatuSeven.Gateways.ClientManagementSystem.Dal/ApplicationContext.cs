using Microsoft.EntityFrameworkCore;
using SatuSeven.Gateways.ClientManagementSystem.Dal.Entities;

namespace SatuSeven.Gateways.ClientManagementSystem.Dal;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
        Database.MigrateAsync();
    }

    public DbSet<CompanyEntity> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<CompanyEntity>()
            .HasIndex(x => x.Slug)
            .IsUnique();
    }
}