using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SM.Channel.API.Endpoints.Validators;
using SM.Channel.API.Models.Requests;
using SM.Channel.API.Models.Responses;
using SM.Channel.API.Services;

namespace SM.Channel.API.Endpoints
{
    public static class ChannelEndpointsDefination
    {
        public static void MapChannelEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("api/v1/Channel")
                .WithOpenApi()
                .WithTags("User's Channel")
                .RequireAuthorization("User");

            group.MapGet("/user/{userId:long}", async (
                [FromRoute] long userId,
                [FromServices] IChannelService channelService,
                CancellationToken cancellationToken) =>
            {
                var channels = await channelService.GetChannelsByUserIdAsync(userId, cancellationToken);
                return Results.Ok(channels);
            })
            .Produces<IEnumerable<ChannelDetailsResponse>>()
            .Produces(StatusCodes.Status404NotFound);

            group.MapGet("/{channelId:long}", async (
                [FromRoute] long channelId,
                [FromServices] IChannelService channelService,
                CancellationToken cancellationToken) =>
            {
                var channel = await channelService.GetChannelByIdAsync(channelId, cancellationToken);
                return Results.Ok(channel);
            })
            .Produces<ChannelDetailsResponse>()
            .Produces(StatusCodes.Status404NotFound);

            group.MapPost("/", async (
                [FromBody] ChannelCreateRequest request,
                [FromServices] IChannelService channelService,
                CancellationToken cancellationToken) =>
            {
                await channelService.CreateChannelAsync(request.ChannelName, request.UserId, cancellationToken);
                return Results.Created($"/api/v1/Channel/{request.UserId}", null);
            })
            .AddEndpointFilter<ValidationFilter<ChannelCreateRequest>>()
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            group.MapPost("/{channelId:long}/users/{userId:long}", async (
                [FromRoute] long channelId,
                [FromRoute] long userId,
                [FromServices] IChannelService channelService,
                CancellationToken cancellationToken) =>
            {
                await channelService.AddUserToChannelAsync(channelId, userId, cancellationToken);
                return Results.Ok();
            })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

            group.MapPut("/", async (
                [FromBody] ChannelUpdateRequest request,
                [FromServices] IChannelService channelService,
                CancellationToken cancellationToken) =>
            {
                await channelService.UpdateChannelAsync(request.ChannelId, request.ChannelName, cancellationToken);
                return Results.Ok();
            })
            .AddEndpointFilter<ValidationFilter<ChannelUpdateRequest>>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            group.MapDelete("/{channelId:long}", async (
                [FromRoute] long channelId,
                [FromServices] IChannelService channelService,
                CancellationToken cancellationToken) =>
            {
                await channelService.DeleteChannelAsync(channelId, cancellationToken);
                return Results.NoContent();
            })
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
