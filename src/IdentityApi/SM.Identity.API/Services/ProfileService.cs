using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SM.Identity.API.Services
{
    public class ProfileService<TUser> : IProfileService
         where TUser : IdentityUser
    {
        private readonly UserManager<TUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProfileService(UserManager<TUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);
            var claims = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("email", user.Email)
            };

            // Add roles to claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim("User", role));
                claims.Add(new Claim("ChannelAdmin", role));
            }

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);
            context.IsActive = user != null;
        }
    }
}
