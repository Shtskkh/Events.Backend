using Events.Hosts.ClickHouseMigrator;

await Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => { services.AddHostedService<ClickHouseMigrationWorker>(); }
    ).Build()
    .RunAsync();