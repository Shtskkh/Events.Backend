using Events.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure.DependencyInjection;

public static class InfrastructureExtensions
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure()
        {
            services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        }
    }
}