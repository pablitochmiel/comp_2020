using Utils;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var person =new Person();
            Assert.Null(person.Name);
            person.Name = "Pawel C";
            Assert.Equal("Pawel C",person.Name);
        }
    }
}