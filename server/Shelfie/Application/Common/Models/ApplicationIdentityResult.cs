using Shelfie.Application.Common.Interfaces;

namespace Shelfie.Application.Common.Models
{
    public class ApplicationIdentityResult
    {
        public bool Succeeded 
        {
            get => Errors.Count() > 0 ? false : true;
        }
        public List<string> Errors { get; set; } = [];
    }
}
