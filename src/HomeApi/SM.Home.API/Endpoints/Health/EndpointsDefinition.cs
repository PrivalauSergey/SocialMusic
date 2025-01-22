using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SM.Home.API.Endpoints.Health
{
    public static class EndpointsDefinition
    {
        public static RouteGroupBuilder MapHealth(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("health")
                .WithOpenApi()
                .WithTags("Health Endpoints");

            group.MapGet("/", () => "ok").Produces(StatusCodes.Status200OK);

            return group;
        }
    }
}
