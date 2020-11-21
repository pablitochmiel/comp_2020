using App.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test
{
    public class ApplicationDbContextTest
    {
        [Fact]
        public void Test1()
        {
            var applicationDbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            Assert.NotNull(applicationDbContext);
        }
    }
}