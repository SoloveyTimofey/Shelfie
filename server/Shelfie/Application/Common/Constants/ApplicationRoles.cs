using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelfie.Application.Common.Constants
{
    public static class ApplicationRoles
    {
        public const string Administrator = "Administrator";
        public const string User = "User";

        public static IEnumerable<string> GetAllRoles()
        {
            yield return Administrator;
            yield return User;
        }
    }
}
