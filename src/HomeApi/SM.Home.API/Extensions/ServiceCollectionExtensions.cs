using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SM.Home.API.Configurations;

namespace SM.Home.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string BearerSchema = "Bearer";
        private const string OAuthSchemaName = "OAuth";

        public static void AddJwtAuthentication(this IServiceCollection services, ApplicationSettings settings)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                });
        }
    }
}
