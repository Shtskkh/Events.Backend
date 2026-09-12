using System.Reflection;
using Microsoft.OpenApi;

namespace Events.Hosts.API.Extensions;

/// <summary>
///     Расширение для добавления OpenAPI.
/// </summary>
public static class OpenApiExtensions
{
    extension(IServiceCollection services)
    {
        /// <summary>
        ///     Метод добавления OpenAPI с метаданными.
        /// </summary>
        public void AddOpenApiWithMetadata()
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "0.26.2",
                    Title = "Events API",
                    Description = "Документация API сервиса управления мероприятиями."
                });

                // Комментарии для API.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));

                // Комментарии и аннотации для DTO.
                var modelsXmlFilename = $"{Assembly.Load("Events.Contracts").GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, modelsXmlFilename));
            });
        }
    }
}