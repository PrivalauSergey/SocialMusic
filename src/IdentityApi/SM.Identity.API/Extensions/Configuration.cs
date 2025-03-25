using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SM.Identity.API.Data;
using SM.Identity.API.Services;
using SM.Identity.API.Middlewares;
using SM.Identity.API.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Duende.IdentityServer.Services;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using static Duende.IdentityServer.IdentityServerConstants;
using Microsoft.Extensions.Configuration;

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
            rsa.ImportFromPem(settings.PrivateKey);

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

            app.Run();
        }
    }
}
