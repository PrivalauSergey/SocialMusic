# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy just the solution and project files first
COPY ["src/HomeApi/SM.Home.API/SM.Home.API.csproj", "SM.Home.API/"]
RUN dotnet restore "SM.Home.API/SM.Home.API.csproj"

# Copy everything else
COPY . .

# Build and publish
RUN dotnet publish "src/HomeApi/SM.Home.API/SM.Home.API.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SM.Home.API.dll"]
EXPOSE 8082