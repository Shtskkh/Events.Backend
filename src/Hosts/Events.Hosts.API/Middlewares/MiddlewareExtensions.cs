using Events.Hosts.API.Middlewares.Exceptions;

namespace Events.Hosts.API.Middlewares;

/// <summary>
///     Extension методы для middlewares проекта.
/// </summary>
public static class MiddlewareExtensions
{
    extension(IApplicationBuilder app)
    {
        /// <summary>
        ///     Метод добавления собственных middleware.
        /// </summary>
        public void AddMiddlewares()
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}