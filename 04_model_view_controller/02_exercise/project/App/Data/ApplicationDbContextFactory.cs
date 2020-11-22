using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Data
{
    [ExcludeFromCodeCoverage]
     public class ApplicationDbContextFactory: IDesignTimeDbContextFactory<ApplicationDbContext>
     {
         public ApplicationDbContext CreateDbContext(string[]? args)
         {
             var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
             if (args!=null && args.Length != 0 && args![0].Equals("memory", StringComparison.InvariantCulture))
             {
                 optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("app");
             }
             else
             {
                 //optionsBuilder.UseSqlite("Data Source=app.db",  b => b.MigrationsAssembly("App"));
             }
             return new ApplicationDbContext(optionsBuilder.Options);
         }
     }
}