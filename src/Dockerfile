FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
WORKDIR /src/Hosts/Events.Hosts.API
RUN dotnet restore
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /src/Hosts/Events.Hosts.API/out .
ENTRYPOINT ["dotnet", "Events.Hosts.API.dll"]