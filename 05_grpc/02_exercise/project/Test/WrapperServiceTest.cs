using System;
using Server.Services;
using Wrap;
using Xunit;

namespace Test
{
    public class WrapperServiceTest
    {
        [Fact]
        public void ReplyTest()
        {
            var reply = new WrapperService().WrapText(new WrapRequest {Text = "slowo slowo2 slowo3", NCol = 8}, null!);
            Assert.Equal("slowo sl\nowo2 slo\nwo3\n",reply.Result.Text);
        }
        
        [Fact]
        public async System.Threading.Tasks.Task NullRequestTest()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(()=>new WrapperService().WrapText(null!, null!));
        }
    }
}