using Events.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure();

var app = builder.Build();

app.Run();