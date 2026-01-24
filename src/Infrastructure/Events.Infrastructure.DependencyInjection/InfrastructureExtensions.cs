using Events.Application.Services.Features.Events.Repositories;
using Events.Infrastructure.DataAccess;
using Events.Infrastructure.DataAccess.Context.Events.Repositories;
using Events.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure.DependencyInjection;

public static class InfrastructureExtensions
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.ConfigureDbConnection(configuration);

            services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));

            services.RegisterRepositories();
        }

        private void ConfigureDbConnection(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContextPool<EventsDbContext>(options => options.UseNpgsql(connectionString,
                optionBuilder => { optionBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery); }));
        }

        private void RegisterRepositories()
        {
            services.AddScoped<IEventRepository, EventRepository>();
        }
    }
}