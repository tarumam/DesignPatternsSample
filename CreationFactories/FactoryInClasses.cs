using System;

namespace Creational.Factories.FactoryInClasses
{
    //Separating facctory methods in classes... So we can have a point factory
    //Factory is a separated component which knows initialize types ina particular way

    
    public class Point
    {
        private readonly double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"FactoryMethod In Classes: {nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        //A property is just a combination of methods
        //Singleton field to get a 0,0 point (just initialize statif field once)
        public static Point Origin = new Point(0, 0);

        public static class Factory
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
        }

    }
}
