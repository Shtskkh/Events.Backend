using Events.Hosts.S3Migrator;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
        {
            services.AddServices(hostContext.Configuration);
            services.AddHostedService<S3MigrationWorker>();
        }
    )
    .Build()
    .RunAsync();