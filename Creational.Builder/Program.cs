using Creational.BuilderCodingExerc;
using Creational.BuilderFacade;
using System;

namespace Creational.Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Call with no builder 
            Console.WriteLine("With no builder");
            var nb = new WithNoBuilder();
            Console.WriteLine(" \n ****************************** \n");

            //call with builder with recursive generics
            Console.WriteLine("Recursive generics");
            var brg = new BuilderInheritance();
            Console.WriteLine(" \n ****************************** \n");

            // call builder with facade
            Console.WriteLine("Builder With Facade");
            var bf = new BuilderWithFacade();
            Console.WriteLine(" \n ****************************** \n");

            // call builder with facade
            Console.WriteLine("Builder Coding Exercise");
            var bce = new BuilderCodingExercise();
            Console.WriteLine(" \n ****************************** \n");

            Console.ReadKey();
        }
    }
}
