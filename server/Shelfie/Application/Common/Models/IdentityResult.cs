namespace Shelfie.Application.Common.Models
{
    public class IdentityResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
