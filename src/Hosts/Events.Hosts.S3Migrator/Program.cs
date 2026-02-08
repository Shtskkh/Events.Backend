using Events.Hosts.S3Migrator;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
        {
            services.AddServices(hostContext.Configuration);
            services.AddHostedService<S3MigrationWorker>();
        }
    )
    .Build()
    .RunAsync();