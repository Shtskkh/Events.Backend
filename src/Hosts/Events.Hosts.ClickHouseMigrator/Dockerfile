FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV DOTNET_NUGET_SIGNATURE_VERIFICATION=false
WORKDIR /src
COPY ["src/Hosts/Events.Hosts.ClickHouseMigrator/Events.Hosts.ClickHouseMigrator.csproj", "src/Hosts/Events.Hosts.ClickHouseMigrator/"]
COPY ["src/Infrastructure/Events.Infrastructure.Analytics/Events.Infrastructure.Analytics.csproj", "src/Infrastructure/Events.Infrastructure.Analytics/"]
COPY ["src/Application/Events.Application.Services/Events.Application.Services.csproj", "src/Application/Events.Application.Services/"]
COPY ["src/Contracts/Events.Contracts/Events.Contracts.csproj", "src/Contracts/Events.Contracts/"]
COPY ["src/Domain/Events.Domain/Events.Domain.csproj", "src/Domain/Events.Domain/"]
RUN dotnet restore "src/Hosts/Events.Hosts.ClickHouseMigrator/Events.Hosts.ClickHouseMigrator.csproj"
COPY . .
WORKDIR "/src/src/Hosts/Events.Hosts.ClickHouseMigrator"
RUN dotnet build "./Events.Hosts.ClickHouseMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Events.Hosts.ClickHouseMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Events.Hosts.ClickHouseMigrator.dll"]
