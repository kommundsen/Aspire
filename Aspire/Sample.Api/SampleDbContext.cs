using Microsoft.EntityFrameworkCore;

namespace Sample.Api;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions options) : base(options)
    {
    }

    protected SampleDbContext()
    {
    }

    public DbSet<SampleData> TestData { get; set; } = null!;
}