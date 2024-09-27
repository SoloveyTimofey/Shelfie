using Shelfie.Application.Common.Models;

namespace Shelfie.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        //Task<string?> GetUserNameAsync(string userId);
        //Task<bool> IsInRoleAsync(string userId, string role);

        Task<IdentityResult> Register(string userName, string password, string email);
        Task<IdentityResult> DeleteAccount(string userId, string password);
        Task<(string?, IdentityResult)> Login(string userName, string password);
    }
}
