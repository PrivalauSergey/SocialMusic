using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SM.Home.API.Configurations;
using SM.Home.API.Endpoints;
using SM.Home.API.Endpoints.Account.Models;
using SM.Home.API.Endpoints.Account.Validators;
using SM.Home.API.Services;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Tabasco.Scheduler.ApiClient;

namespace SM.Home.API
{
    public static class Programm
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // configure logging
            if (!builder.Environment.IsDevelopment())
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

            var rsa = RSA.Create();
            rsa.ImportFromPem(settings.IdentityClientSettings.PublicKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = settings.IdentityClientSettings.ClientUrl;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "api",
                    ValidIssuer = settings.IdentityClientSettings.ClientUrl,
                    ValidateLifetime = true,
                    IssuerSigningKey = new RsaSecurityKey(rsa)
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireRole("User"));
                options.AddPolicy("ChannelAdmin", policy => policy.RequireRole("ChannelAdmin"));
            });

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Home Api", Version = "v1" });

                opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>() }
                });
            });

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
            services.AddIdentityClient(settings.IdentityClientSettings);


            var app = builder.Build();

            app.UseHttpLogging();

            if (builder.Environment.IsDevelopment())
            {
                app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API v1"));
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapApplicationEndpoints();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
