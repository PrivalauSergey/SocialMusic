using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using SM.Identity.API.Models;
using SM.Identity.API.Models.Account;
using SM.Identity.API.Models.Login;
using SM.Identity.API.Services.Interfaces;

namespace SM.Identity.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenCreationService _tokenCreationService;

        public AccountService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ITokenCreationService tokenCreationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenCreationService = tokenCreationService;
        }

        public async Task<ApiResponse<AccountCreateResponse>> CreateAccountAsync(string username, string email, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                await _userManager.AddToRoleAsync(user, "ChannelAdmin");

                var token = await GenerateTokenAsync(user);
                return new ApiResponse<AccountCreateResponse>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = new AccountCreateResponse { Token = token }
                };
            }

            return new ApiResponse<AccountCreateResponse>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Data = null
            };
        }

        public async Task<ApiResponse<UserLoginResponse>> LoginAsync(string login, string password)
        {
            var user = await _userManager.FindByNameAsync(login) ?? await _userManager.FindByEmailAsync(login);

            if (user == null)
            {
                return new ApiResponse<UserLoginResponse>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Data = null
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                var token = await GenerateTokenAsync(user);
                return new ApiResponse<UserLoginResponse>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = new UserLoginResponse { Token = token }
                };
            }

            return new ApiResponse<UserLoginResponse>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Data = null
            };
        }

        private async Task<string> GenerateTokenAsync(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("sub", user.Id),
                new Claim("username", user.UserName),
                new Claim("email", user.Email)
            };

            // Add roles to claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            // Create a token descriptor
            var tokenDescriptor = new Token
            {
                Issuer = "http://localhost:8081",
                Audiences = ["api"],
                Claims = claims,
                Lifetime = 3600 // 1 hour
            };

            // Generate the token
            var token = await _tokenCreationService.CreateTokenAsync(tokenDescriptor);
            return token;
        }
    }
}
