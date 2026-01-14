using Events.Hosts.DbMigrator;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
        {
            services.AddServices(hostContext.Configuration);
            services.AddHostedService<MigrationWorker>();
        }
    ).Build()
    .RunAsync();