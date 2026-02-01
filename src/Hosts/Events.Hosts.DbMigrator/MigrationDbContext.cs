using Events.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Events.Hosts.DbMigrator;

/// <summary>
///     Контекст базы данных для миграции.
/// </summary>
public class MigrationDbContext : EventsDbContext
{
    /// <summary>
    ///     Конструктор контекста для миграции.
    /// </summary>
    /// <param name="options">Опции контекста базы данных.</param>
    public MigrationDbContext(DbContextOptions options) : base(options)
    {
    }
}