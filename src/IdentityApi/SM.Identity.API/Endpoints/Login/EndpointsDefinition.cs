using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Threading;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;

namespace SM.Identity.API.Endpoints.Login
{
    public static class EndpointsDefinition
    {
        public static RouteGroupBuilder MapLogin(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("Login")
                .WithTags("Authorization/Authentication");

            group.MapGet("/auth/ui", async (
                HttpContext httpContext,
                CancellationToken cancelationToken) =>
            {
                httpContext.Response.ContentType = "text/html; charset=utf-8";
                var returnUrlValue = httpContext.Request.Query["returnUrl"].ToString();
                if (string.IsNullOrWhiteSpace(returnUrlValue)) returnUrlValue = "/";
                var html = $@"<!doctype html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <title>Identity - Login / Register</title>
                </head>
                <body>
                    <h1>Sign in / Register</h1>
                    <form id='authForm' method='post' action='/account/login'>
                    <input name='username' id='login' placeholder='username' /> <br/>
                    <input name='password' id='password' type='password' placeholder='password' /> <br/>
                    <input type='hidden' name='returnUrl' value='{System.Net.WebUtility.HtmlEncode(returnUrlValue)}' />
                    <button type='submit'>Login</button>
                    </form>
                    <p>Or register via the API endpoints.</p>
                </body>
                </html>";

                await httpContext.Response.WriteAsync(html);
            })
             .AllowAnonymous();

            // OIDC interaction endpoints: IdentityServer will redirect to /account/login with returnUrl
            endpoints.MapGet("/account/login", async (HttpContext ctx, IIdentityServerInteractionService interaction) =>
            {
                var returnUrl = ctx.Request.Query["returnUrl"].ToString();
                ctx.Response.ContentType = "text/html; charset=utf-8";
                var html = $@"<!doctype html>
<html>
<head><meta charset='utf-8' /><title>Login</title></head>
<body>
<h1>Sign in</h1>
<form method='post' action='/account/login'>
<input name='username' placeholder='username' /> <br/>
<input name='password' type='password' placeholder='password' /> <br/>
<input type='hidden' name='returnUrl' value='{System.Net.WebUtility.HtmlEncode(returnUrl)}' />
<button type='submit'>Login</button>
</form>
</body>
</html>";
                await ctx.Response.WriteAsync(html);
            }).AllowAnonymous();

            endpoints.MapPost("/account/login", async (HttpContext ctx, IIdentityServerInteractionService interaction, TestUserStore users) =>
            {
                var form = await ctx.Request.ReadFormAsync();
                var username = form["username"].ToString();
                var password = form["password"].ToString();
                var returnUrl = form["returnUrl"].ToString();

                if (!users.ValidateCredentials(username, password))
                {
                    ctx.Response.StatusCode = 400;
                    await ctx.Response.WriteAsync("Invalid credentials");
                    return;
                }

                var user = users.FindByUsername(username);
                var claims = new List<Claim>
                {
                    new Claim("sub", user.SubjectId),
                    new Claim("name", user.Username)
                };
                foreach (var c in user.Claims)
                {
                    claims.Add(new Claim(c.Type, c.Value));
                }

                var identity = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(identity);

                // sign in the user with IdentityServer's cookie
                await ctx.SignInAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme, principal);

                // validate return url - if valid return to authorization request, otherwise go to root
                if (interaction.IsValidReturnUrl(returnUrl))
                {
                    ctx.Response.Redirect(returnUrl);
                }
                else
                {
                    ctx.Response.Redirect("/");
                }
            }).AllowAnonymous();

            return group;
        }
    }
}
