using Blazor.Shared;
using Xunit;

namespace Test
{
    public class SharedTest
    {
        [Fact]
        public void NavMenuTest()
        {
            var menu =new NavMenu();
            Assert.True(menu.CollapseNavMenu);
            Assert.Equal("collapse",menu.NavMenuCssClass);
            menu.ToggleNavMenu();
            Assert.False(menu.CollapseNavMenu);
            Assert.Null(menu.NavMenuCssClass);
        }
        
        [Fact] 
        public void TestTitle()
        {
            var survey = new SurveyPrompt();
            Assert.Null(survey.Title);
            survey.Title = "title";
            Assert.Equal("title", survey.Title);
        }
    }
}