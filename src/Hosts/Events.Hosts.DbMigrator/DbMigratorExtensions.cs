using Microsoft.EntityFrameworkCore;

namespace Events.Hosts.DbMigrator;

public static class DbMigratorExtensions
{
    extension(IServiceCollection services)
    {
        public void AddServices(IConfiguration configuration)
        {
            services.ConfigureDbConnection(configuration);
        }

        private void ConfigureDbConnection(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContextPool<MigrationDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}