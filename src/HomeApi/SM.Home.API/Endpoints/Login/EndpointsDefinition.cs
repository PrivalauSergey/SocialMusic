using System.Net;
using System.Threading;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SM.Home.API.Endpoints.Account.Models;
using SM.Home.API.Services;
using SM.Home.API.Shared;
using LoginRequest = SM.Home.API.Endpoints.Account.Models.LoginRequest;

namespace SM.Home.API.Endpoints.Login
{
    public static class EndpointsDefinition
    {
        public static RouteGroupBuilder MapLogin(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("Login")
                .WithOpenApi()
                .WithTags("Log in");

            group.MapPost("/", async (
                [FromBody] LoginRequest login,
                IAccountService accountService,
                IValidator<LoginRequest> validator,
                HttpContext httpContext,
                CancellationToken cancelationToken) =>
            {
                var validationResult = validator.Validate(login);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.ToResponse());
                }

                var response = await accountService.Login(
                    login.Login,
                    login.EncryptedPassword,
                    login.IvHex);

                return response.StatusCode switch
                {
                    HttpStatusCode.OK => Results.Ok(response.Data),
                    HttpStatusCode.BadRequest => Results.BadRequest(),
                    _ => Results.InternalServerError()
                };
            })
             .AllowAnonymous()
             .Produces(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status400BadRequest)
             .Produces(StatusCodes.Status500InternalServerError);

            return group;
        }
    }
}
