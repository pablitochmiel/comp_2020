using Xunit;
using Microsoft.Extensions.DependencyInjection;


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
        
        [Fact]
        public void CreatingBar()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IFoo, Foo>();
            serviceCollection.AddTransient<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.IsType<Bar>(serviceProvider.GetService<Bar>());
        }

        [Fact]
        public void AddTransient()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IFoo, Foo>();
            serviceCollection.AddTransient<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            /*var example = serviceProvider.GetService<Bar>();
            var example2 = serviceProvider.GetService<Bar>();*/
            Assert.NotEqual(serviceProvider.GetService<Bar>(),serviceProvider.GetService<Bar>());
        }
        
        [Fact]
        public void AddSingleton()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFoo, Foo>();
            serviceCollection.AddSingleton<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.Equal(serviceProvider.GetService<Bar>(),serviceProvider.GetService<Bar>());
        }
        
        [Fact]
        public void AddScoped()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IFoo, Foo>();
            serviceCollection.AddScoped<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.Equal(serviceProvider.GetService<Bar>(),serviceProvider.GetService<Bar>());
            var anotherServiceProvider = serviceCollection.BuildServiceProvider();
            Assert.NotEqual(serviceProvider.GetService<Bar>(),anotherServiceProvider.GetService<Bar>());
        }
    }
}