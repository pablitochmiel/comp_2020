using System;
using Greet;
using Service.Services;
using Xunit;

namespace Test
{
    public class GreeterServiceTest
    {
        [Fact]
        public void ReplyTest()
        {
            var reply = new GreeterService().SayHello(new HelloRequest{Name = "test"},null! );
            Assert.Equal("Hello test",reply.Result.Message);
        }
        
        [Fact]
        public async System.Threading.Tasks.Task NullRequestTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(()=>new GreeterService().SayHello(null!, null!));
        }
    }
}