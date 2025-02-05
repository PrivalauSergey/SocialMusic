using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SM.Home.API.Endpoints.Channel
{
    public static class EndpointsDefinition
    {
        public static RouteGroupBuilder MapChannel(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("Channel")
                .WithOpenApi()
                .WithTags("User's Channel")
                .RequireAuthorization("User", "ChannelAdmin");
            
            group.MapPost("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized);

            group.MapGet("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized);

            group.MapPut("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized);

            group.MapDelete("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized);

            return group;
        }
    }
}
