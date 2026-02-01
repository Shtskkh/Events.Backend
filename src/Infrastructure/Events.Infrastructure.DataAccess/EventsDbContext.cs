using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess;

/// <summary>
///     Контекст базы данных приложения.
/// </summary>
public class EventsDbContext : DbContext
{
    /// <summary>
    ///     Конструктор контекста базы данных приложения.
    /// </summary>
    /// <param name="options">Опции контеста базы данных.</param>
    public EventsDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}