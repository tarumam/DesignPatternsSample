using System;

namespace Creational.Factories.NoFactory
{
    public enum CoordinatesSystem
    {
        Cartesian,
        Polar
    }

    //Class with no factory method
    public class Point
    {
        private readonly double x, y;

        ///There is a problem here because the constructor is getting convoluted, so, to simplify it we should use factory method

        /// <summary>
        /// Initialize a point from either cartesiaon or polar
        /// </summary>
        /// <param name="a">x if cartesian, rho if polar</param>
        /// <param name="b">y if cartesian, theta if polar</param>
        /// <param name="system"></param>
        public Point(double a, double b, CoordinatesSystem system = CoordinatesSystem.Cartesian)
        {
            switch (system)
            {
                case CoordinatesSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinatesSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sin(b);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        public override string ToString()
        {
            return $"No Factory Method: {nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}
