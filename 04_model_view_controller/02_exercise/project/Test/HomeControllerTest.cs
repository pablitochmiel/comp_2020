using System.Diagnostics;
using App.Controllers;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Test
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            var mock = new Mock<ILogger<HomeController>>();
            var homeController=new HomeController(mock.Object);
            Assert.NotNull(homeController);
            var res=homeController.Index();
            Assert.NotNull(res);
            Assert.IsType<ViewResult>(res);
            homeController.Dispose();
        }
        
        [Fact]
        public void Privacy()
        {
            var mock = new Mock<ILogger<HomeController>>();
            var homeController=new HomeController(mock.Object);
            Assert.NotNull(homeController);
            var res=homeController.Privacy();
            Assert.NotNull(res);
            Assert.IsType<ViewResult>(res);
            homeController.Dispose();
        }
        
        [Fact]
        public void Error()
        {
            var mock = new Mock<ILogger<HomeController>>();
            var homeController=new HomeController(mock.Object);
            
            var mockContext = new Mock<HttpContext>();
            var mockRequest=new Mock<HttpRequest>();
            mockContext.Setup(x => x.Request).Returns(mockRequest.Object);
            homeController.ControllerContext=new ControllerContext(new ActionContext(mockContext.Object,new RouteData(),new ControllerActionDescriptor() ));
            
            var res=homeController.Error();
            Assert.NotNull(res);
            Assert.IsType<ViewResult>(res);
            var viewResult = Assert.IsType<ViewResult>(res);
            var model = Assert.IsAssignableFrom<ErrorViewModel>(viewResult.ViewData.Model);
            
            Assert.Equal(Activity.Current?.Id,model.RequestId);
            Assert.False(model.ShowRequestId);

            homeController.Dispose();
        }

        [Fact]
        public void ErrorViewModelTest()
        {
            var errorViewModel=new ErrorViewModel{RequestId = "xyz"};
            Assert.True(errorViewModel.ShowRequestId);
        }
    }
}