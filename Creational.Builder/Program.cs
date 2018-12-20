using System;

namespace Creational.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call with no builder pattern
            //var nb = new WithNoBuilder();


            //call with builder with recursive generics
            var brg = new BuilderInheritance();

            Console.ReadKey();
        }
    }
}
