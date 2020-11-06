using System;

namespace Utils
{
    public class Demo
    {
        private readonly string _name;

        public Demo(string name)
        {
            _name = name;
        }

        public void Run()
        {
            Console.WriteLine($"Hello {_name}!");
        }
    }
}