using System;

namespace Creational.Factories
{
    public class Program
    {

        private static void Main(string[] args)
        {
            #region With no Factory

            Console.WriteLine("No factory cartesian point");
            var cartesianPoint = new NoFactory.Point(123.222222, -99.32322, NoFactory.CoordinatesSystem.Cartesian);
            Console.WriteLine(cartesianPoint);
            Console.WriteLine(" \n ****************************** \n");

            Console.WriteLine("No factory Polar Point");
            var polarPoint = new NoFactory.Point(1.0, Math.PI / 2, NoFactory.CoordinatesSystem.Polar);
            Console.WriteLine(polarPoint);
            Console.WriteLine(" \n ****************************** \n");

            #endregion

            #region Factory Method

            Console.WriteLine("Factory Mehtod cartesian point");
            var factoryCartesianPoint = FactoryMethod.Point.NewCartesianPoint(123.222222, -99.32322);
            Console.WriteLine(factoryCartesianPoint);
            Console.WriteLine(" \n ****************************** \n");

            Console.WriteLine("Factory Method polar point");
            var factoryPolarPoint = FactoryMethod.Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(factoryPolarPoint);
            Console.WriteLine(" \n ****************************** \n");

            #endregion

            #region Factory Method in Classes

            Console.WriteLine("Factory Mehtod in Classes cartesian point");
            var factoryIcCartesian = FactoryInClasses.Point.Factory.NewCartesianPoint(123.222222, -99.32322);
            Console.WriteLine(factoryIcCartesian);
            Console.WriteLine(" \n ****************************** \n");

            Console.WriteLine("Factory Method in Classes polar point");
            var factoryIcPolar = FactoryInClasses.Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(factoryIcPolar);
            Console.WriteLine(" \n ****************************** \n");

            Console.WriteLine("Factory Method in Classes Origin Point Field");
            var factoryIcField = FactoryInClasses.Point.Origin;
            Console.WriteLine(factoryIcField);
            Console.WriteLine(" \n ****************************** \n");

            #endregion

            #region Abstract Factory
            Console.WriteLine("Abstract Factory");
            var machine = new HotDrinkMachine();
            var coffe = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffe, 2);
            var tea = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 4);
            Console.WriteLine(" \n ****************************** \n");

            #endregion

            #region Abstract Factory with OCP (Open Close Principle)
            Console.WriteLine("Abstract Factory OCP");
            var machineOcp = new AbstractFactoryOCP.HotDrinkMachine();
            var drink = machineOcp.MakeDrink();
            drink.Consume();
            Console.WriteLine(" \n ****************************** \n");
            #endregion
            Console.ReadKey();

        }
    }
}
