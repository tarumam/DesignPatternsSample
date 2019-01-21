using System;
using static System.Console;

namespace Structural.Decorator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Multiple inheritance
            WriteLine("Multiple inheritance");
            var d = new Dragon();
            d.Weight = 10;
            d.Fly();
            d.Crawl();
            WriteLine("****************************\n");
            #endregion

            #region DecoratorComposite
            WriteLine("DecoratorComposite");
            var square = new Square(1.23f);
            WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "red");
            WriteLine(redSquare.AsString());

            var redHalfTransparentSquare = new TransparedShape(redSquare, 0.5f);
            WriteLine(redHalfTransparentSquare.AsString());

            WriteLine("****************************\n");
            #endregion

            #region DecoratorComposite
            WriteLine("Static decorator composition");
            //here is possibile to inform the color of instancied class, however is not possible to initialize the class square
            var rSquare = new Static.ColoredShape<Static.Square>("red");
            WriteLine(rSquare.AsString());

            var rCircle = new Static.TransparentShape<Static.ColoredShape<Static.Circle>>(0.04f);
            WriteLine(rCircle.AsString());
            
            WriteLine("****************************\n");
            #endregion

            Console.ReadKey();

        }
    }
}
