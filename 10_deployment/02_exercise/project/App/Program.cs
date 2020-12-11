using System;
using System.Diagnostics.CodeAnalysis;
using Utils;

namespace App
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main()
        {
            var person = new Person{Name="Pawel C"};
            Console.WriteLine(person.Name);
        }
    }
}