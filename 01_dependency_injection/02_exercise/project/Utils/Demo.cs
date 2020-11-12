using Microsoft.Extensions.Logging;

namespace Utils
{
    public class Demo
    {
        // private readonly string _name;
        //
        // public Demo()
        // {
        //     _name = name;
        // }
        
        private readonly ILogger<Demo> _logger;
        
        public Demo(ILogger<Demo> logger)
        {
            _logger = logger;
        }

        public void Run(string name)
        {
            _logger.LogInformation($"Hello {name}!");
        }
    }
}