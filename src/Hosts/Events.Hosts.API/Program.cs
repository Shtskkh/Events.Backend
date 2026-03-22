using Events.Application.Services;
using Events.Hosts.API.Extensions;
using Events.Hosts.API.Middlewares;
using Events.Infrastructure.Analytics;
using Events.Infrastructure.DataAccess;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddAnalytics(builder.Configuration);

builder.Services.AddApplication();

builder.Services.AddControllers();

builder.Services.AddOpenApiWithMetadata();

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddApiServices();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapScalarApiReference(options => { options.WithOpenApiRoutePattern("/swagger/v1/swagger.json"); });
}

app.UseAuthentication();
app.UseAuthorization();

app.AddMiddlewares();

app.MapControllers();

app.Run();