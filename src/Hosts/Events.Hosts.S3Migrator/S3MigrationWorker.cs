using Amazon.S3;
using Amazon.S3.Util;

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
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var s3Client = scope.ServiceProvider.GetRequiredService<IAmazonS3>();
            var buckets = configuration.GetSection("S3:Buckets").GetChildren();

            foreach (var bucket in buckets)
            {
                var bucketName = bucket.Value;

                if (logger.IsEnabled(LogLevel.Information))
                    logger.LogInformation("Migrating bucket: {bucketName}", bucketName);

                var bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);

                if (!bucketExists)
                {
                    await s3Client.PutBucketAsync(bucketName, cancellationToken);

                    if (logger.IsEnabled(LogLevel.Information))
                        logger.LogInformation("Bucket created: {bucketName}", bucketName);
                }
                else
                {
                    if (logger.IsEnabled(LogLevel.Information))
                        logger.LogInformation("Bucket already exists: {bucketName}", bucketName);
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