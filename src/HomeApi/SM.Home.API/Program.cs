using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SM.Home.API.Clients.IndentityClient;
using SM.Home.API.Configurations;
using SM.Home.API.Endpoints;
using SM.Home.API.Endpoints.Account.Models;
using SM.Home.API.Endpoints.Account.Validators;
using SM.Home.API.Extensions;
using SM.Home.API.Services;

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

            services.AddSwaggerGen();

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

            services.AddEndpointsApiExplorer();

            // Services
            services.AddSingleton<IAccountService, AccountService>();

            // Validation
            services.AddSingleton<IValidator<CreateAccountRequest>, CreateAccountRequestValidator>();
            services.AddSingleton<IValidator<LoginRequest>, LogInRequestValidator>();

            // Clients
            services.AddSingleton<IIdentityApiClient, IdentityApiClientMock>();


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

            app.MapApplicationEndpoints();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
