using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelfie.Application.Common.Models
{
    public class ApplicationIdentityResultWithReturnValue : ApplicationIdentityResult
    {
        public string? Token { get; set; } = null;
    }
}
