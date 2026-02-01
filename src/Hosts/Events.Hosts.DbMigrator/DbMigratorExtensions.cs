using Microsoft.EntityFrameworkCore;

namespace Events.Hosts.DbMigrator;

/// <summary>
///     Расширения мигратора.
/// </summary>
public static class DbMigratorExtensions
{
    extension(IServiceCollection services)
    {
        /// <summary>
        ///     Метод добавления сервисов в worker.
        /// </summary>
        /// <param name="configuration">Конфигурация приложения.</param>
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