using Blazor.Pages;
using Xunit;

namespace Test
{
    public class CounterPageTest
    {
        [Fact]
        public void CounterTest()
        {
            var page = new Counter();
            Assert.Equal(0,page.CurrentCount);
            page.IncrementCount();
            page.IncrementCount();
            Assert.Equal(2,page.CurrentCount);
        }
    }
}