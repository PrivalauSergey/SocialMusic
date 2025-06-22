using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SM.Identity.API.Configuration;
using SM.Identity.API.Data;
using SM.Identity.API.Middlewares;
using SM.Identity.API.Services;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Duende.IdentityServer.IdentityServerConstants;

namespace SM.Identity.API.Extensions
{
    public static class Configuration
    {
        public static async Task RegisterServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.Configure<ApplicationSettings>(builder.Configuration);
            var settings = new ApplicationSettings();
            builder.Configuration.Bind(settings);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("IdentityDb"));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var rsa = RSA.Create();
            rsa.ImportFromPem(Encoding.UTF8.GetString(Convert.FromBase64String(settings.PrivateKey)));

            services.AddIdentityServer()
                .AddSigningCredential(new RsaSecurityKey(rsa), RsaSigningAlgorithm.RS512)
                .AddInMemoryIdentityResources(IdentityApiScopeConfiguration.IdentityResources)
                .AddInMemoryApiScopes(IdentityApiScopeConfiguration.ApiScopes)
                .AddInMemoryClients(IdentityApiScopeConfiguration.Clients)
                .AddProfileService<ProfileService<IdentityUser>>();

            services.AddTransient<IProfileService, ProfileService<IdentityUser>>();

            // Add services
            services.AddTransient<IAccountService, AccountService>();

            services.AddControllers();

            services.AddHealthChecks();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await SeedData.Initialize(context, userManager, roleManager);
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.MapControllers();

            app.MapHealthChecks("/health");
            app.MapHealthChecks("/ready");

            app.Run("http://0.0.0.0:8081");
        }
    }
}
