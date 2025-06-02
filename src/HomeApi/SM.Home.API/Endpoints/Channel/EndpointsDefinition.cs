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
                .RequireAuthorization("User");

            group.MapPost("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status403Forbidden);

            group.MapGet("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status403Forbidden);

            group.MapPut("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status403Forbidden);

            group.MapDelete("/", () => { return Results.Ok(); })
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status403Forbidden);

            return group;
        }
    }
}
