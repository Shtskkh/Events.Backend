using Events.Application.Services.Interfaces;
using Events.Hosts.API.Services;

namespace Events.Hosts.API.Extensions;

public static class ApiServicesExtensions
{
    extension(IServiceCollection services)
    {
        public void AddApiServices()
        {
            services.AddScoped<ICurrentUserProvider, HttpCurrentUserProvider>();
        }
    }
}