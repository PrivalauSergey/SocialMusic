using Duende.IdentityServer.Test;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using SM.Identity.API.Configuration;
using SM.Identity.API.Endpoints;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SM.Identity.API
{
    public static class Program
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

            var settings = new ApplicationSettings();
            services.Configure<ApplicationSettings>(builder.Configuration);
            builder.Configuration.Bind(settings);

            var rsa = RSA.Create();
            rsa.ImportFromPem(Encoding.UTF8.GetString(Convert.FromBase64String(settings.PrivateKey)));

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddInMemoryIdentityResources(AuthScopeConfig.IdentityResources)
            .AddInMemoryApiScopes(AuthScopeConfig.ApiScopes)
            .AddInMemoryApiResources(AuthScopeConfig.ApiResources)
            .AddInMemoryClients(AuthScopeConfig.Clients)
            .AddTestUsers(
            [
                new TestUser { SubjectId = "1", Username = "alice", Password = "Pass123$", Claims = [new Claim("role","User")] },
                new TestUser { SubjectId = "2", Username = "bob", Password = "Pass123$", Claims = [new Claim("role","ChannelAdmin")] }
            ])
            .AddSigningCredential(new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = "http://localhost:8081"; // Identity server hosted here
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity Api", Version = "v1" });
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

            services.AddHealthChecks();

            var app = builder.Build();

            app.UseHttpLogging();

            if (builder.Environment.IsDevelopment())
            {
                app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API v1"));
            }

            app.UseIdentityServer();

            app.MapApplicationEndpoints();

            app.MapHealthChecks("/health");
            app.MapHealthChecks("/ready");

            app.Run("http://*:8081");
        }
    }
}
