using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Utils;

namespace App
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            // TODO: Create and use DB context...
            using (var db = new ProjectContext())
            {
                var project = new Project {Name = "nazwa",Description = "opis",CreationDate = DateTime.Now};
                db.Projects?.Add(project);
                db.SaveChanges();
            }

            using (var db = new ProjectContext())
            {
                var projects = (db.Projects ?? throw new NullReferenceException()).ToList();

                foreach (var project in projects)
                {
                    Console.WriteLine(project.Id.ToString(provider: null) + project.Name! + project.Description +
                                      project.CreationDate);
                }
            }

            //Console.WriteLine("Hello World!");
        }
    }
}