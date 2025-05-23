﻿using SM.Identity.API.Client;
using SM.Identity.API.Client.Models;
using SM.Identity.API.Client.Models.Account;
using SM.Identity.API.Client.Models.Login;
using System.Threading.Tasks;

namespace SM.Home.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IIdentityClient _indetityClient;

        public AccountService(IIdentityClient indetityApiClient)
        {
            _indetityClient = indetityApiClient;
        }

        public async Task<ApiResponse<AccountCreateResponse>> CreateAccount(
            string login,
            string password,
            string email,
            string ivHex)
        {
            var accountRequest = new AccountCreateRequest 
            { 
                UserName = login,
                EncrryptPassword = password,
                Email = email,
                IvHex = ivHex 
            };

            return await _indetityClient.CreateAccount(accountRequest);
        }

        public async Task<ApiResponse<UserLoginResponse>> Login(
            string login,
            string password,
            string ivHex)
        {
            var userLoginRequest = new UserLoginRequest
            {
                Login = login,
                EncrryptPassword = password,
                IvHex = ivHex
            };

            return await _indetityClient.Login(userLoginRequest);
        }
    }
}
