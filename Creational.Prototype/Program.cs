using Creational.Prototype.CopyThroughSerialization;
using System;

namespace Creational.Prototype
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region IClonable is a bad idea
            Console.WriteLine("IClonable is bad");
            var john = new Person(new[] { "John", "smith" }, new Address("London Road", 123));

            //Bad idea - Notice that it was a shallow copy - when you copy john like that, you are copping only the reference, so the house number and name of john have been changed also
            //if we implement IClonable in Address Object it gonna work as we want, however it is not a good aproach for PrototypeDesignPatter that requires a deepcopy
            var jane = (Person)john.Clone();
            jane.Address.HouseNumber = 321;
            jane.Names[0] = "Jane";

            Console.WriteLine(john);
            Console.Write(jane);

            Console.WriteLine(" \n ****************************** \n");

            #endregion

            #region CopyConstructor
            Console.WriteLine("Copy Constructor");
            var johnCopyConstructor = new CopyConstructor.Person(new[] { "John", "smith" }, new CopyConstructor.Address("London Road", 123));

            var janeCopyConstructor = new CopyConstructor.Person(johnCopyConstructor);
            janeCopyConstructor.Address.HouseNumber = 321;
            janeCopyConstructor.Names[0] = "Jane";

            Console.WriteLine(johnCopyConstructor);
            Console.Write(janeCopyConstructor);

            Console.WriteLine(" \n ****************************** \n");
            #endregion

            #region DeepCopy Interface making use of Copy Constructor
            Console.WriteLine("DeepCopy Interface making use of Copy Constructor");
            var pIJohn = new DeepCopyInterface.Person(new[] { "John", "smith" }, new DeepCopyInterface.Address("London Road", 123));

            //This method is not deepcoping the Names array.
            var pIJane = pIJohn.DeepCopy();
            pIJane.Address.HouseNumber = 321;
            pIJane.Names[0] = "Jane";

            Console.WriteLine(pIJohn);
            Console.Write(pIJane);

            Console.WriteLine(" \n ****************************** \n");
            #endregion

            #region DeepCopy Serialization (Real world)
            Console.WriteLine("DeepCopy Serialization (Real world)");
            var sJohn = new CopyThroughSerialization.Person(new[] { "John", "smith" }, new CopyThroughSerialization.Address("London Road", 123));

            //This method is not deepcoping the Names array.
            var sJane = sJohn.DeepCopy();
            sJane.Address.HouseNumber = 321;
            sJane.Names[0] = "Jane";

            Console.WriteLine(sJohn);
            Console.WriteLine(sJane);

            //Using objects from another namespace to show that xml copy does not need objects marked as [Serializable]
            var xJohn = new Person(new[] { "John", "smith" }, new Address("London Road", 123));
            var xJane = xJohn.DeepCopyXml();
            xJane.Address.HouseNumber = 321;
            xJane.Names[0] = "Jane";

            Console.WriteLine(xJohn);
            Console.WriteLine(xJane);

            Console.WriteLine(" \n ****************************** \n");
            #endregion

            #region Prototype Coding Exercise
            Console.WriteLine("Coding Exercise");
            var line = new Line
            {
                Start = new Point { X = 10, Y = 12 },
                End = new Point { X = 23, Y = 26 }
            };
            var newLine = line.DeepCopy();
            newLine.Start.X = 99;
            newLine.End.Y = 44;

            Console.WriteLine(line.Start.X);
            Console.WriteLine(newLine.Start.X);
            #endregion

            Console.ReadKey();

        }
    }
}
