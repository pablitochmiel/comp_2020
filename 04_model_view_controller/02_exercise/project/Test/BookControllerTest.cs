using App.Controllers;
using App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Utils;
using Xunit;

namespace Test
{

    public class BookControllerTest
    {
        [Fact]
        public void Book()
        {
            var book = new Book {BookId = 1, Title = "a", Description = "b"};
            Assert.Equal(1,book.BookId);
            Assert.Equal("a",book.Title);
            Assert.Equal("b",book.Description);
        }
        [Fact]
        public void Index()
        {
            var mock = new Mock<ILogger<BookController>>();
            var dbcontext=new ApplicationDbContextFactory().CreateDbContext(new[] {"memory"});
            var bookController = new BookController(mock.Object,dbcontext);
            Assert.NotNull(bookController);
            var res = bookController.Index();
            Assert.NotNull(res);
            Assert.IsType<ViewResult>(res);
            bookController.Dispose();
        }
        
        [Fact]
        public void Create()
        {
            var mock = new Mock<ILogger<BookController>>();
            var dbcontext=new ApplicationDbContextFactory().CreateDbContext(new[] {"memory"});
            var bookController = new BookController(mock.Object,dbcontext);
            Assert.NotNull(bookController);
            var res = bookController.Create();
            Assert.NotNull(res);
            Assert.IsType<ViewResult>(res);
            bookController.Dispose();
        }
        
        [Fact]
        public void Store()
        {
            Assert.True(false);// nie umiem przetestowac
        }
    }
}