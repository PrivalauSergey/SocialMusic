using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SM.Identity.API.Constants;
using SM.Identity.API.Exceptions;
using SM.Identity.API.Services.Interfaces;

namespace SM.Identity.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;

        public AccountService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        public async Task<string> CreateAccountAsync(string userName, string email, string password)
        {
            await ValidateUserUniqueness(userName, email);

            var user = new IdentityUser { UserName = userName, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            
            if (!result.Succeeded)
                throw new ValidationException("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));

            await EnsureRolesExistAndAssignUser(user);
            return await _jwtService.GenerateTokenAsync(user);
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            var user = await FindUserByLoginAsync(login);

            if (user == null)
                throw new NotFoundException("Login failed: User not found");

            if (!await _userManager.CheckPasswordAsync(user, password))
                throw new NotFoundException("Login failed: Incorrect password");

            return await _jwtService.GenerateTokenAsync(user);
        }

        private async Task EnsureRolesExistAndAssignUser(IdentityUser user)
        {
            var tasks = Enum.GetNames(typeof(DefaultRoles)).Select(async role =>
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                    await _roleManager.CreateAsync(new IdentityRole(role));

                await _userManager.AddToRoleAsync(user, role);
            });

            await Task.WhenAll(tasks);
        }

        private async Task ValidateUserUniqueness(string userName, string email)
        {
            if (await _userManager.FindByNameAsync(userName) != null)
                throw new ValidationException($"User with the name `{userName}` already exists");

            if (await _userManager.FindByEmailAsync(email) != null)
                throw new ValidationException($"User with the email `{email}` already exists");
        }

        private async Task<IdentityUser> FindUserByLoginAsync(string login)
        {
            // Determine if 'login' is an email or a username
            return login.Contains("@") ?
                await _userManager.FindByEmailAsync(login) :
                await _userManager.FindByNameAsync(login);
        }
    }
}
