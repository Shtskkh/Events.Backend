using Events.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Events.Hosts.DbMigrator;

public class MigrationDbContext : EventsDbContext
{
    public MigrationDbContext(DbContextOptions options) : base(options)
    {
    }
}