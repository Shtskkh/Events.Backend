using Amazon.S3;
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
                logger.LogInformation("Start S3 migration: {time}", DateTimeOffset.Now);

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
                        logger.LogInformation("Bucket created: {bucketName}", bucket);
                }
                else
                {
                    if (logger.IsEnabled(LogLevel.Information))
                        logger.LogInformation("Bucket already exists: {bucketName}", bucket);
                }
            }

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("End S3 migration: {time}", DateTimeOffset.Now);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error during S3 migration");
            throw;
        }
        finally
        {
            applicationLifetime.StopApplication();
        }
    }
}