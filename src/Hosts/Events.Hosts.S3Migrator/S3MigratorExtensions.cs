using Amazon.Runtime;
using Amazon.S3;

namespace Events.Hosts.S3Migrator;

public static class S3MigratorExtensions
{
    extension(IServiceCollection services)
    {
        public void AddServices(IConfiguration configuration)
        {
            services.AddS3Client(configuration);
        }

        private void AddS3Client(IConfiguration configuration)
        {
            services.AddSingleton<IAmazonS3>(_ =>
            {
                var endpoint = configuration["S3:Endpoint"];
                var accessKey = configuration["S3:AccessKey"];
                var secretKey = configuration["S3:SecretKey"];

                var config = new AmazonS3Config
                {
                    ServiceURL = endpoint,
                    ForcePathStyle = true
                };

                var credentials = new BasicAWSCredentials(accessKey, secretKey);

                return new AmazonS3Client(credentials, config);
            });
        }
    }
}