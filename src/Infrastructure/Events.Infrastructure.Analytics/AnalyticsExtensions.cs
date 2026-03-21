using ClickHouse.Driver;
using Events.Application.Services.Features.Analytics.Repositories;
using Events.Infrastructure.Analytics.Context.PageViews.Repositories;
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
            // Для read-only операций.
            services.AddDbContextPool<AnalyticsDbContext>(options => options.UseClickHouse(connectionString));

            // Для вставки. Временное решение, поскольку библиотека ClickHouse для EF ещё не поддерживает вставку через EF
            // (хотя документация говорит, что можно).
            services.AddSingleton(new ClickHouseClient(connectionString));
        }

        private void RegisterRepositories()
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IPageViewRepository, PageViewRepository>();
        }
    }
}