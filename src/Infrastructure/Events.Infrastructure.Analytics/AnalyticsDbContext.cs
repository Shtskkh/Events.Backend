using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Analytics;

/// <summary>
///     Контекст базы данных аналитики приложения.
/// </summary>
public class AnalyticsDbContext : DbContext
{
    public AnalyticsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}