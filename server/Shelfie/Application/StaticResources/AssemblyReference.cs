using System.Reflection;

namespace Shelfie.Application.StaticResources
{
    public class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
