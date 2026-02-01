using Microsoft.EntityFrameworkCore;

namespace Events.Hosts.DbMigrator;

/// <summary>
///     Worker мигратора.
/// </summary>
/// <param name="serviceProvider">
///     Проводник сервисов для создания scope.
/// </param>
/// <param name="applicationLifetime">
///     Для завершения работы после миграций.
/// </param>
/// <param name="logger">Логгер.</param>
public class MigrationWorker(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime applicationLifetime,
    ILogger<MigrationWorker> logger
) : BackgroundService
{
    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!stoppingToken.IsCancellationRequested)
            try
            {
                if (logger.IsEnabled(LogLevel.Information))
                    logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using var scope = serviceProvider.CreateScope();

                var context = scope.ServiceProvider.GetService<MigrationDbContext>();
                await context.Database.MigrateAsync(stoppingToken);

                if (logger.IsEnabled(LogLevel.Information))
                    logger.LogInformation("Worker completed at: {time}", DateTimeOffset.Now);
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured during migration");
                throw;
            }
            finally
            {
                applicationLifetime.StopApplication();
            }
    }
}