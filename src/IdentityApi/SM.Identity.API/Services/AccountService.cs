using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SM.Home.API.Configurations;
using SM.Identity.API.Configuration;
using SM.Identity.API.Models;
using SM.Identity.API.Models.Account;
using SM.Identity.API.Models.Login;

namespace SM.Identity.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IOptions<ApplicationSettings> _apiConfigrations;
        private readonly ITokenCreationService _tokenCreationService;

        public AccountService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IOptions<ApplicationSettings> apiConfigrations,
            ITokenCreationService tokenCreationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _apiConfigrations = apiConfigrations;
            _tokenCreationService = tokenCreationService;
        }

        public async Task<ApiResponse<AccountCreateResponse>> CreateAccountAsync(
            string username,
            string email,
            string encrryptPassword,
            string ivHex)
        {
            var password = Decrypt(encrryptPassword, ivHex);

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

        public async Task<ApiResponse<UserLoginResponse>> LoginByNameOrEmailAsync(
            string login,
            string encrryptPassword,
            string ivHex)
        {
            var password = Decrypt(encrryptPassword, ivHex);

            var identityUser = await _userManager.FindByNameAsync(login) ?? await _userManager.FindByEmailAsync(login);

            if (identityUser == null)
            {
                return new ApiResponse<UserLoginResponse>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Data = null
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(identityUser, password, false);

            if (result.Succeeded)
            {
                var token = await GenerateTokenAsync(identityUser);
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
                Issuer = _apiConfigrations.Value.ApiConfigurations.IdentityApiBaseUrl,
                Audiences = ["api"],
                Claims = claims,
                Lifetime = 3600
            };

            // Generate the token
            var token = await _tokenCreationService.CreateTokenAsync(tokenDescriptor);
            return token;
        }

        private string Decrypt(string cipherText, string ivHex)
        {
            try
            {
                using var aes = Aes.Create();
                aes.Key = Convert.FromBase64String(_apiConfigrations.Value.SecureKey);
                aes.IV = HexToBytes(ivHex);
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                using var decryptor = aes.CreateDecryptor();
                using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var reader = new StreamReader(cs);

                return reader.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
        }

        private static byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
