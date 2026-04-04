# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy just the solution and project files first
COPY ["src/IdentityApi/SM.Identity.API/SM.Identity.API.csproj", "SM.Identity.API/"]
RUN dotnet restore "SM.Identity.API/SM.Identity.API.csproj"

# Copy everything else
COPY . .

# Build and publish
RUN dotnet publish "src/IdentityApi/SM.Identity.API/SM.Identity.API.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SM.Identity.API.dll"]
EXPOSE 8081