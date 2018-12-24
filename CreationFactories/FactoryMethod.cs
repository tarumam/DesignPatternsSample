using System;

//With factory method
namespace Creational.Factories.FactoryMethod
{
    public class Point
    {
        //factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        //factory method
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private readonly double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"FactoryMethod: {nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}
