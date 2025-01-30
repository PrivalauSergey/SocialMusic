using Microsoft.Extensions.DependencyInjection;
using SM.Identity.API.Client;

namespace Tabasco.Scheduler.ApiClient
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityClient(this IServiceCollection services, IdentityClientSettings settings)
        {
            services.AddHttpClient<IIdentityClient, IdentityClient>(
                httpClient =>
                {
                    httpClient.BaseAddress = new Uri(settings.ClientUrl);
                });

            services.AddSingleton(settings);

            return services;
        }
    }
}