using Microsoft.EntityFrameworkCore;
using SatuSeven.Company.Dal.Entities;

namespace SatuSeven.Company.Dal;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<CompanyEntity> Companies { get; set; }
}