using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class Roles
    {
        public const string Administrator = "Administrator";

        public static IEnumerable<string> GetAllRoles()
        {
            yield return Administrator;
        }
    }
}
