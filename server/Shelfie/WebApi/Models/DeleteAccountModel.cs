using System.ComponentModel.DataAnnotations;

namespace Shelfie.WebApi.Models
{
    public sealed class DeleteAccountModel
    {
        [Required(ErrorMessage = "Username is required.")] public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required.")] public string Password { get; set; } = string.Empty;
    }
}
