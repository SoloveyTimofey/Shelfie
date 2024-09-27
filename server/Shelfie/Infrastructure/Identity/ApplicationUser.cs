using Shelfie.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Shelfie.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
    }
}
