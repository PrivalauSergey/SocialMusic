using System;
using Microsoft.Extensions.DependencyInjection;

namespace SM.Channel.API.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChannelClient(this IServiceCollection services, ChannelClientSettings settings)
        {
            services.AddHttpClient<IChannelClient, ChannelClient>(
                httpClient =>
                {
                    httpClient.BaseAddress = new Uri(settings.ClientUrl);
                });

            services.AddSingleton(settings);

            return services;
        }
    }
}
