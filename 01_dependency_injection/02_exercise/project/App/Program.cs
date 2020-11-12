using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Utils;

namespace App
{
    internal static class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main()
        {
            // var demo = new Demo("John");
            // demo.Run();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(logging => logging.AddConsole());
            serviceCollection.AddScoped<Demo>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var demo = serviceProvider.GetService<Demo>();
            demo.Run("John");
        }
    }
}
