using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Events.Hosts.API.Extensions;

/// <summary>
///     Расширения для добавления JWT.
/// </summary>
public static class JwtExtensions
{
    extension(IServiceCollection services)
    {
        /// <summary>
        ///     Метод добавления JWT аутентификации.
        /// </summary>
        /// <param name="configuration">Конфигурация приложения.</param>
        public void AddJwt(IConfiguration configuration)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = configuration.GetValue<bool>("Jwt:ValidateLifetime"),
                        ValidateIssuer = configuration.GetValue<bool>("Jwt:ValidateIssuer"),
                        ValidateAudience = configuration.GetValue<bool>("Jwt:ValidateAudience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };

                    options.MapInboundClaims = false;
                });
        }
    }
}