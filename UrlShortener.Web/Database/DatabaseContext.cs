using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Web.Database;

public class DatabaseContext : DbContext
{
    public DbSet<UrlEntity> Urls { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlEntityConfiguration).Assembly);
    }
}