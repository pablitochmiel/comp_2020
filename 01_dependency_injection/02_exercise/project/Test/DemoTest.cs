using System;
using System.IO;
using Moq;
using Utils;
using Xunit;

namespace Test
{
    public class DemoTest
    {
        [Fact]
        public void Run()
        {
            var mock = new Mock<TextWriter>();
            Console.SetOut(mock.Object);

            const string name = "John";
            mock.Setup(tw => tw.WriteLine($"Hello {name}!"));
            
            var demo = new Demo(name);
            demo.Run();
        }
    }
}