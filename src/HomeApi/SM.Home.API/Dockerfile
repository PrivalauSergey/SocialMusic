# Use ASP.NET Core runtime (adjust version if needed)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8082

# Build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SM.Home.API.csproj", "."]
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "SM.Home.API.dll"]