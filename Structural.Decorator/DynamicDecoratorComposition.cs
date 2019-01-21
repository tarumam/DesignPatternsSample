using System;

namespace Structural.Decorator
{
    public interface Shape
    {
        string AsString();
    }

    public class Circle : Shape
    {
        private float radius;
        public Circle()
        {

        }
        public Circle(float radius)
        {
            this.radius = radius;
        }

        public string AsString() => $"A circle with radius {radius}";
        public void Resize(float factor)
        {
            radius *= factor;
        }
    }

    public class Square : Shape
    {
        private readonly float side;
        public Square()
        {

        }
        public Square(float side)
        {
            this.side = side;
        }
        public string AsString() => $"A square with side {side}";
    }

    public class ColoredShape : Shape
    {
        private Shape shape;
        private readonly string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }

        public string AsString() => $"{shape.AsString()} has the color {color}";
    }

    public class TransparedShape : Shape
    {
        private readonly Shape shape;
        private readonly float transparency;

        public TransparedShape(Shape shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.transparency = transparency;
        }

        public string AsString() => $"{shape.AsString()} has {transparency * 100.0}% transparency.";
    }
}
