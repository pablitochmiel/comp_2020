using Microsoft.EntityFrameworkCore;
using Utils;

namespace App
{
    public class ProjectContext:DbContext
    {
        public DbSet<Project>? Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=project.db");
        }
    }
}                                               