using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shelfie.Application.Common.Interfaces;
using Shelfie.Application.Common.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Shelfie.Application.Common.Constants;

namespace Shelfie.Infrastructure.Identity
{
    internal class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public IdentityService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ApplicationIdentityResultWithReturnValue> RegisterAsync(string userName, string password, string email)
        {
            ApplicationIdentityResultWithReturnValue applicationIdentityResult = new ApplicationIdentityResultWithReturnValue();

            var existedUser = await _userManager.FindByNameAsync(userName);
            if (existedUser != null)
            {
                applicationIdentityResult.Errors.Add(ExceptionMessages.UserNameIsAlreadyTaken);
                return applicationIdentityResult;
            }

            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var userResult = await _userManager.CreateAsync(user, password);
            var roleResult = await _userManager.AddToRoleAsync(user, ApplicationRoles.User);

            if (userResult.Succeeded && roleResult.Succeeded)
            {
                var token = await GenerateToken(userName, user);
                applicationIdentityResult.Token = token;
                
                return applicationIdentityResult;
            }
            else
            {
                applicationIdentityResult.Errors.AddRange(userResult.Errors.Select(error=>error.Description));
            }

            return applicationIdentityResult;
        }
        public async Task<ApplicationIdentityResult> DeleteAccountAsync(string username, string password)
        {
            var identityResult = new ApplicationIdentityResult();

            var user = await _userManager.FindByNameAsync(username);
            if (user!=null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return identityResult;
                    }
                    else
                    {
                        identityResult.Errors.AddRange(result.Errors.Select(error=>error.Description));

                        return identityResult;
                    }
                }
            }

            identityResult.Errors.Add(ExceptionMessages.InvalidUserNameOrPassword);

            return identityResult;
        }

        public async Task<ApplicationIdentityResultWithReturnValue> LoginAsync(string userName, string password)
        {
            var applicationIdentityResult = new ApplicationIdentityResultWithReturnValue();

            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    var token = await GenerateToken(userName, user);
                    applicationIdentityResult.Token = token;
                    return applicationIdentityResult;
                }
            }

            applicationIdentityResult.Errors.Add(ExceptionMessages.InvalidUserNameOrPassword);
            return applicationIdentityResult;
        }

        private async Task<string?> GenerateToken(string userName, ApplicationUser user)
        {
            var secret = _configuration["JwtConfiguration:Secret"];
            var issuer = _configuration["JwtConfiguration:ValidIssuer"];
            var audience = _configuration["JwtConfiguration:ValidAudiences"];

            bool isConfigExpirationMinutesInt =
                int.TryParse(
                     _configuration["JwtConfiguration:MinutesAfterKeyExpires"] ?? throw new ApplicationException(ExceptionMessages.JwtIsNotSetInTheConfiguration),
                     out int minutesAfterTokenExpires
                );

            if (secret is null || issuer is null || audience is null)
            {
                throw new ApplicationException(ExceptionMessages.JwtIsNotSetInTheConfiguration);
            }
            if (!isConfigExpirationMinutesInt)
            {
                throw new ApplicationException(ExceptionMessages.ExpirationTimeIsNotInt);
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenHandler = new JwtSecurityTokenHandler();

            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, userName)
            };
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(minutesAfterTokenExpires),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
