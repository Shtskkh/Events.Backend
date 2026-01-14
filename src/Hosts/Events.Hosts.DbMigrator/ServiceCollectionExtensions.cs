using Microsoft.EntityFrameworkCore;

namespace Events.Hosts.DbMigrator;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddServices(IConfiguration configuration)
        {
            services.ConfigureDbConnection(configuration);

            return services;
        }

        private void ConfigureDbConnection(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContextPool<MigrationDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}