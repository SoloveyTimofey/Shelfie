using System.Reflection;

namespace Shelfie.Domain.StaticResources
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
