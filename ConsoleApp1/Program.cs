using BusinessLayer.Concrete;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryRepository a = new CategoryRepository();
            a.List();
            Console.ReadKey();
        }
    }
}
