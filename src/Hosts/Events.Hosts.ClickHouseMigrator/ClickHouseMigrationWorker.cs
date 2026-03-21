using System.Reflection;
using ClickHouse.Driver.ADO;

namespace Events.Hosts.ClickHouseMigrator;

/// <summary>
///     Worker мигратора.
/// </summary>
/// <param name="configuration">Конфигурация приложения.</param>
/// <param name="applicationLifetime">Для завершения работы после миграций.</param>
/// <param name="logger">Логгер.</param>
public class ClickHouseMigrationWorker(
    IConfiguration configuration,
    IHostApplicationLifetime applicationLifetime,
    ILogger<ClickHouseMigrationWorker> logger
) : BackgroundService
{
    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (stoppingToken.IsCancellationRequested) return;

        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Начата миграция ClickHouse: {time}", DateTimeOffset.Now);

            var connectionString = configuration.GetConnectionString("DbConnection")!;
            await RunMigrationsAsync(connectionString, stoppingToken);

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("ClickHouse migrator completed at: {time}", DateTimeOffset.Now);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occured during ClickHouse migration");
            throw;
        }
        finally
        {
            applicationLifetime.StopApplication();
        }
    }

    private static async Task RunMigrationsAsync(string connectionString, CancellationToken ct)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var sqlResources = assembly
            .GetManifestResourceNames()
            .Where(name => name.Contains(".Migrations.") && name.EndsWith(".sql"))
            .OrderBy(name => name);

        foreach (var resourceName in sqlResources)
        {
            await using var stream = assembly.GetManifestResourceStream(resourceName)!;
            using var reader = new StreamReader(stream);
            var sql = await reader.ReadToEndAsync(ct);

            var isBootstrap = resourceName.Contains(".000_");
            var connStr = isBootstrap ? GetBootstrapConnectionString(connectionString) : connectionString;

            await using var connection = new ClickHouseConnection(connStr);
            await using var command = connection.CreateCommand();
            command.CommandText = sql;
            await command.ExecuteNonQueryAsync(ct);
        }
    }

    private static string GetBootstrapConnectionString(string connectionString)
    {
        var builder = new ClickHouseConnectionStringBuilder(connectionString)
        {
            Database = "default"
        };

        return builder.ToString();
    }
}