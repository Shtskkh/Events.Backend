FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .
WORKDIR /src/Hosts/Events.Hosts.S3Migrator/
RUN dotnet restore
RUN dotnet publish -c $BUILD_CONFIGURATION -o publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /migrator
COPY --from=build /src/Hosts/Events.Hosts.S3Migrator/publish .
ENTRYPOINT ["dotnet", "Events.Hosts.S3Migrator.dll"]