using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SM.Home.API.Filters;
using SM.Identity.API.Endpoints.Login;

namespace SM.Identity.API.Endpoints
{
    public static class ApplicationEndpointsDefinition
    {
        public static void MapApplicationEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("api/v1")
                .AddEndpointFilter<SecurityHeadersEndpointFilter>();
            group.MapLogin();
        }
    }
}
