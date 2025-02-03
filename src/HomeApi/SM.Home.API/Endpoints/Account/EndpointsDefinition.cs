using System.Threading;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SM.Home.API.Endpoints.Account.Models;
using SM.Home.API.Services;
using SM.Home.API.Shared;

namespace SM.Home.API.Endpoints.Account
{
    public static class EndpointsDefinition
    {
        public static RouteGroupBuilder MapAccounts(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("Account")
                .WithOpenApi()
                .WithTags("User's Accounts");

            group.MapPost("/", async (
                [FromBody] CreateAccountRequest account,
                IAccountService accountService,
                IValidator<CreateAccountRequest> validator,
                HttpContext httpContext,
                CancellationToken cancelationToken) =>
            {
                var validationResult = validator.Validate(account);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.ToResponse());
                }

                var response = await accountService.CreateAccount(account.Username, account.Password, account.Email);

                return Results.Ok(response);
            })
             .AllowAnonymous()
             .Produces(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status400BadRequest);

            return group;
        }
    }
}
