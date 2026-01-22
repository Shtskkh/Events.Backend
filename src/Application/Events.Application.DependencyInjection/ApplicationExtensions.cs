using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Application.DependencyInjection;

public static class ApplicationExtensions
{
    extension(IServiceCollection services)
    {
        public void AddApplication()
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}