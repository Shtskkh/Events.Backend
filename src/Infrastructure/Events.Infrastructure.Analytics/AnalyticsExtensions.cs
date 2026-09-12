using Events.Application.Services.Shared;
using Events.Infrastructure.Analytics.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure.Analytics;

public static class AnalyticsExtensions
{
    extension(IServiceCollection services)
    {
        public void AddAnalytics(IConfiguration configuration)
        {
            services.ConfigureDbConnection(configuration);
            services.RegisterRepositories();
        }

        private void ConfigureDbConnection(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AnalyticsDb");
            services.AddDbContextPool<AnalyticsDbContext>(options => options.UseClickHouse(connectionString));
        }

        private void RegisterRepositories()
        {
            services.AddScoped(typeof(IAnalyticsRepository<>), typeof(AnalyticsRepository<>));
        }
    }
}