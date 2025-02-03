using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SM.Identity.API.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(IdentityUser user);
    }
}