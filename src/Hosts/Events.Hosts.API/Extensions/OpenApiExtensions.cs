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
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info.Title = "Events API";
                    document.Info.Version = "v0.26.1";
                    document.Info.Description = "API сервиса управления мероприятиями.";

                    return Task.CompletedTask;
                });
            });
        }
    }
}