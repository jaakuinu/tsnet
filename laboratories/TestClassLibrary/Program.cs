using System;

namespace TestClassLibrary
{
    using ModelCodeFirst;
    class Program
    {
        static void Main(string[] args)
        {
            int customer = API.AddCustomer("Ionel", "Iasi");

            Console.WriteLine("Hello World!");
        }
    }
}
