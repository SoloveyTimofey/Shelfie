using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelfie.Application.Common.Constants
{
    public static class ExceptionMessages
    {
        #region Identity
        public const string UserNameIsAlreadyTaken = "User name is already taken.";
        public const string JwtIsNotSetInTheConfiguration = "Jwt is not set in the configuration.";
        public const string ExpirationTimeIsNotInt = "Jwt Expiration time set in the configuration, but its value is not int.";
        public const string ExpirationTimeIsNotSetInTheConfiguration = "Expiration time is not set in the configuration.";
        public const string InvalidUserNameOrPassword = "Invalid user name or password.";
        #endregion

        public static IEnumerable<string> GetAllMessages()
        {
            yield return UserNameIsAlreadyTaken;
            yield return JwtIsNotSetInTheConfiguration;
            yield return ExpirationTimeIsNotInt;
            yield return ExpirationTimeIsNotSetInTheConfiguration;
        }
    }
}
