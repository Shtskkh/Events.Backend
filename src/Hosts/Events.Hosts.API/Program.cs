using Events.Application.Services;
using Events.Hosts.API.Extensions;
using Events.Infrastructure.DependencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddControllers();

builder.Services.AddOpenApiWithMetadata();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapScalarApiReference(options => { options.WithOpenApiRoutePattern("/swagger/v1/swagger.json"); });
}

app.MapControllers();

app.Run();