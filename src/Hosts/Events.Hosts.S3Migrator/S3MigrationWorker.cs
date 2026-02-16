using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using Events.Application.Services.Features.Files;

namespace Events.Hosts.S3Migrator;

public class S3MigrationWorker(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime applicationLifetime,
    ILogger<S3MigrationWorker> logger
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Старт миграции S3 хранилища: {time}", DateTimeOffset.Now);

            using var scope = serviceProvider.CreateScope();
            var s3Client = scope.ServiceProvider.GetRequiredService<IAmazonS3>();
            var buckets = S3Buckets.GetAll();

            foreach (var bucket in buckets)
            {
                if (logger.IsEnabled(LogLevel.Information))
                    logger.LogInformation("Migrating bucket: {bucketName}", bucket);

                var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucket);

                if (!bucketExists)
                {
                    await s3Client.PutBucketAsync(bucket, cancellationToken);

                    if (logger.IsEnabled(LogLevel.Information))
                        logger.LogInformation("Bucket создан: {bucketName}", bucket);
                }
                else
                {
                    if (logger.IsEnabled(LogLevel.Information))
                        logger.LogInformation("Bucket уже существует: {bucketName}", bucket);
                }
            }

            await MigrateEventsPlaceholdersAsync(s3Client, logger);

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Конец миграции S3 хранилища. {time}", DateTime.Now);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Ошибка миграции S3 хранилища.");
        }
        finally
        {
            applicationLifetime.StopApplication();
        }
    }

    private static async Task MigrateEventsPlaceholdersAsync(IAmazonS3 s3Client, ILogger<S3MigrationWorker> logger)
    {
        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Начата миграция плейсхолдеров мероприятий. {time}", DateTimeOffset.Now);

            var filesPaths = Directory.GetFiles(
                @"../../Application/Events.Application.Services/Features/Files/Placeholders/EventsPreviews");

            foreach (var filePath in filesPaths)
            {
                var file = File.OpenRead(filePath);
                var filename = Path.GetFileName(filePath).Split('.').First();

                if (logger.IsEnabled(LogLevel.Information))
                    logger.LogInformation("Начата миграция файла: {fileName}. {time}", filename, DateTime.Now);

                await s3Client.PutObjectAsync(new PutObjectRequest
                {
                    BucketName = S3Buckets.EventsPlaceholders,
                    Key = filename,
                    InputStream = file
                });
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Ошибка при миграции плейсхолдеров мероприятий.");
            throw;
        }
    }
}