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

                var response = await accountService.Login(login.Login, login.Password);

                return Results.Ok(response);
            })
             .AllowAnonymous()
             .Produces(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status400BadRequest);

            return group;
        }
    }
}
