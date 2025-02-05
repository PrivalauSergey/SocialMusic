using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SM.Identity.API.Data;
using SM.Identity.API.Services;
using SM.Identity.API.Services.Interfaces;
using SM.Identity.API.Middlewares;
using SM.Identity.API.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Duende.IdentityServer.Services;
using System.Threading.Tasks;

namespace SM.Identity.API.Extensions
{
    public static class Configuration
    {
        public static async Task RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("IdentityDb"));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityApiScopeConfiguration.IdentityResources)
                .AddInMemoryApiScopes(IdentityApiScopeConfiguration.ApiScopes)
                .AddInMemoryClients(IdentityApiScopeConfiguration.Clients)
                .AddProfileService<ProfileService<IdentityUser>>();

            builder.Services.AddTransient<IProfileService, ProfileService<IdentityUser>>();

            // Add services
            builder.Services.AddTransient<IAccountService, AccountService>();

            builder.Services.AddControllers();

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
