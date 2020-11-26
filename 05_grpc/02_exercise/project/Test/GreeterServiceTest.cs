using System;
using Greet;
using Server.Services;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var reply = new GreeterService().SayHello(new HelloRequest{Name = "test"},null! );
            Assert.Equal("Hello test",reply.Result.Message);
        }
        
        [Fact]
        public async System.Threading.Tasks.Task Test2()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(()=>new GreeterService().SayHello(null!, null!));
        }
    }
}