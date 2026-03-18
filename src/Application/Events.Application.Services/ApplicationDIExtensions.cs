using System.Reflection;
using Events.Application.Services.Features.Tokens.Jwt;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Events.Application.Services;

/// <summary>
///     Расширение для внедрения application в приложение.
/// </summary>
public static class ApplicationDiExtensions
{
    extension(IServiceCollection services)
    {
        /// <summary>
        ///     Метод внедрения application.
        /// </summary>
        public void AddApplication()
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddFluentValidationAutoValidation();

            services.RegisterServices();
        }

        private void RegisterServices()
        {
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
        }
    }
}