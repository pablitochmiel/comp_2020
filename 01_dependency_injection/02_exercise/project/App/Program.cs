using System.Diagnostics.CodeAnalysis;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main()
        {
            var demo = new Demo("John");
            demo.Run();
        }
    }
}
