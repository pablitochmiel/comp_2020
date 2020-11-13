using System;
using Utils;
using Xunit;

namespace Test
{
    public class ProjectTest
    {
        [Fact]
        public void CanCreateProject()
        {
            const int id = 1;
            const string name = "N";
            const string description = "D";
            var data = DateTime.Today;
            
            // TODO: Enable in second exercise...
            var uri = new Uri("http://example.com");

            var project = new Project
            {
                Id = id, 
                Name = name, 
                Description = description, 
                CreationDate = data,
                
                // TODO: Enable in second exercise...
                Uri = uri
            };

            Assert.Equal(id, project.Id);
            Assert.Equal(name, project.Name);
            Assert.Equal(description, project.Description);
            Assert.Equal(data, project.CreationDate);
            
            // TODO: Enable in second exercise...
            Assert.Equal(uri, project.Uri);
        }
    }
}