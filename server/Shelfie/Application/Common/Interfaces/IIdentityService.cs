using Shelfie.Application.Common.Models;

namespace Shelfie.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        //Task<string?> GetUserNameAsync(string userId);
        //Task<bool> IsInRoleAsync(string userId, string role);

        Task<ApplicationIdentityResultWithReturnValue> RegisterAsync(string userName, string password, string email);
        Task<ApplicationIdentityResult> DeleteAccountAsync(string userId, string password);
        Task<ApplicationIdentityResultWithReturnValue> LoginAsync(string userName, string password);
    }
}
