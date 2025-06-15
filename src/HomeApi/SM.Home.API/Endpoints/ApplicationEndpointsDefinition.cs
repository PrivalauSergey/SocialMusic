using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Routing;
using SM.Home.API.Endpoints.Account;
using SM.Home.API.Endpoints.Channel;
using SM.Home.API.Endpoints.Health;
using SM.Home.API.Endpoints.Login;
using SM.Home.API.Filters;

namespace SM.Home.API.Endpoints
{
    public static class ApplicationEndpointsDefinition
    {
        public static void MapApplicationEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("api/v1")
                .AddEndpointFilter<SecurityHeadersEndpointFilter>();
            group.MapAccounts();
            group.MapChannel();
            group.MapLogin();
        }
    }
}
