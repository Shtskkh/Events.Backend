using Amazon.Runtime;
using Amazon.S3;
using Events.Application.Services.Features.Events.Repositories;
using Events.Application.Services.Features.Files;
using Events.Infrastructure.DataAccess;
using Events.Infrastructure.DataAccess.Context.Events.Repositories;
using Events.Infrastructure.DataAccess.Repositories;
using Events.Infrastructure.DataAccess.Services.RustFS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure.DependencyInjection;

/// <summary>
///     Расширение для внедрения инфраструктуры в приложение.
/// </summary>
public static class InfrastructureExtensions
{
    extension(IServiceCollection services)
    {
        /// <summary>
        ///     Метод добавления инфраструктуры в приложение.
        /// </summary>
        /// <param name="configuration">Конфигурация приложения.</param>
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.ConfigureDbConnection(configuration);

            services.AddS3(configuration);

            services.RegisterRepositories();

            services.RegisterInfrastructureServices();
        }

        private void ConfigureDbConnection(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContextPool<EventsDbContext>(options => options.UseNpgsql(connectionString,
                optionBuilder => { optionBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery); }));
        }

        private void RegisterRepositories()
        {
            services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
            services.AddScoped<IEventRepository, EventRepository>();
        }

        private void AddS3(IConfiguration configuration)
        {
            services.AddSingleton<IAmazonS3>(_ =>
            {
                var endpoint = configuration["S3:Endpoint"];
                var accessKey = configuration["S3:AccessKey"];
                var secretKey = configuration["S3:SecretKey"];

                var config = new AmazonS3Config
                {
                    ServiceURL = $"http://{endpoint}",
                    ForcePathStyle = true
                };

                var credentials = new BasicAWSCredentials(accessKey, secretKey);

                return new AmazonS3Client(credentials, config);
            });
        }

        private void RegisterInfrastructureServices()
        {
            services.AddScoped<IFileStorageService, RustFsFileStorageService>();
        }
    }
}