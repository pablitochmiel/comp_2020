using Xunit;

namespace Test
{
    internal interface IFoo
    {
        int Test();
    }

    internal class Foo : IFoo
    {
        public int Test()
        {
            return 7;
        }
    }

    internal class Bar
    {
        private readonly IFoo _foo;

        public Bar(IFoo foo)
        {
            _foo = foo;
        }

        public int Test()
        {
            return _foo.Test();
        }
    }

    public class DependencyInjectionTest
    {
        [Fact]
        public void HasSomeTypesForTesting()
        {
            var foo = new Foo();
            var bar = new Bar(foo);
            Assert.Equal(7, bar.Test());
        }

        // TODO: Add tests...
    }
}