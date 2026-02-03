FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/Hosts/Events.Hosts.DbMigrator/
RUN dotnet restore
RUN dotnet build -c Release -o build

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /migrator
COPY --from=build /src/Hosts/Events.Hosts.DbMigrator/build .
ENTRYPOINT ["dotnet", "Events.Hosts.DbMigrator.dll"]