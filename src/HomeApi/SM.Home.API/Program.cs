using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SM.Home.API.Configurations;
using SM.Home.API.Constants;
using SM.Home.API.Extensions;
using System.Collections.Generic;

namespace SM.Home.API
{
    public static class Programm
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // configure logging
            if(!builder.Environment.IsLocal())
            {
                builder.Logging.ClearProviders();
                builder.Logging.AddJsonConsole();
            }
            else
            {
                builder.Services.AddCors();
            }

            var services = builder.Services;

            services.Configure<ApplicationSettings>(builder.Configuration);
            var settings = new ApplicationSettings();
            builder.Configuration.Bind(settings);

            services.AddHttpLogging(options =>
            {
                options.LoggingFields =
                    HttpLoggingFields.RequestPath |
                    HttpLoggingFields.RequestQuery |
                    HttpLoggingFields.RequestMethod |
                    HttpLoggingFields.RequestProtocol |
                    HttpLoggingFields.ResponseStatusCode |
                    HttpLoggingFields.Duration;
                    options.CombineLogs = true;
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    AuthorizationConstants.UserRoleName,
                    policy => policy.RequireRole(
                        AuthorizationConstants.UserRoleName,
                        AuthorizationConstants.ChannelRoleName));
                options.AddPolicy(
                    AuthorizationConstants.ChannelRoleName,
                    policy => policy.RequireRole(
                        AuthorizationConstants.ChannelRoleName));
            });

            services.AddEndpointsApiExplorer();

            services.AddMemoryCache();

            var app = builder.Build();

            app.UseHttpLogging();

            if(builder.Environment.IsLocal())
            {
                app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
