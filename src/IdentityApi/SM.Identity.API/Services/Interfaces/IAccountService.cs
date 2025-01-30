using System.Threading.Tasks;

namespace SM.Identity.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateAccountAsync(string userName, string email, string password);
        Task<string> LoginAsync(string userName, string password);
    }
}
