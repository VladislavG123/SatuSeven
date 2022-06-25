using Microsoft.EntityFrameworkCore;

namespace SatuSeven.Contracts.Abstract.Providers.EntityFramework.Tests.Infrastructure;

public class TestApplicationContext : DbContext
{
    public TestApplicationContext()
    : base(new DbContextOptionsBuilder<TestApplicationContext>()
        .UseInMemoryDatabase("SatuSeven.Contracts.Abstract.Providers.EntityFramework.Tests").Options)
    {
        Database.EnsureDeleted();
    }

    public DbSet<CertainEntity> Entities { get; set; }
}