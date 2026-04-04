using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace SM.Identity.API.Configuration
{
    public static class AuthScopeConfig
    {
        // 1. Which APIs are protected?
        public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("sm.home.api.read", "Read Access to SM.Home.API"),
            new ApiScope("sm.home.api.write", "Write Access to SM.Home.API")
        ];

        // 2. Identity resources
        public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        ];
        // 3. API resources (audiences)
        public static IEnumerable<ApiResource> ApiResources =>
        [
            new ApiResource("sm.home.api", "SM Home API")
            {
                Scopes = { "sm.home.api.read", "sm.home.api.write" }
            }
        ];

        // 3. Which Clients (SPA) can request tokens?
        public static IEnumerable<Client> Clients =>
        [
            new Client
            {
                ClientId = "home_spa",
                ClientName = "Home Single Page App",
                RequireClientSecret = false, // SPA cannot hide secrets

                // Where the user logs in
                RedirectUris = { "http://localhost:4200/auth-callback" },
                // Where the user logs out
                PostLogoutRedirectUris = { "http://localhost:4200" },
                AllowedCorsOrigins = { "http://localhost:4200" },

                // Authorization Code + PKCE for SPA
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                AllowOfflineAccess = true,

                // What the token can access
                AllowedScopes = { "openid", "profile", "sm.home.api.read", "offline_access" },

                // Lifetime of the JWT (seconds)
                AccessTokenLifetime = 3600
            }
        ];
    }
}
