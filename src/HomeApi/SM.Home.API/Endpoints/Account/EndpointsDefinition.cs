using System;
using System.Collections.Generic;
using System.Threading;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace SM.Home.API.Endpoints.Account
{
    public static class EndpointsDefinition
    {
        public static RouteGroupBuilder MapAccounts(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("Accounts")
                .WithOpenApi()
                .WithTags("User accounts");
        }

        /*private readonly IHttpClientFactory _httpClientFactory;

        public EndpointsDefinition(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] AccountCreateRequest userCreateRequest)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:5001/api/account/create-user", userCreateRequest);

            if (response.IsSuccessStatusCode)
            {
                return Ok(new { message = "User created successfully." });
            }

            return BadRequest("Failed to create user.");
        }*/
    }
}
