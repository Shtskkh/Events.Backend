using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.DataAccess;

public class EventsDbContext : DbContext
{
    public EventsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}