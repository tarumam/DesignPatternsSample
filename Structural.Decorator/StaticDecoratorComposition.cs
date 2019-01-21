using System;

namespace Structural.Decorator.Static
{
    //Static decorator is not a good approach unfortunatelly, because is not possible to set property values for classes (inside)
    //for example to  commented property of circle
    public abstract class Shape
    {
        public abstract string AsString();
    }

    public class Circle : Shape
    {
        //Unfortunatelly it is not accessible from my created object from static composition
        public bool ThisIsNotSettable { get; set; }

        private float radius;
        public Circle() : this(0)
        {

        }
        public Circle(float radius)
        {
            this.radius = radius;
        }

        public override string AsString() => $"A circle with radius {radius}";
        public void Resize(float factor)
        {
            radius *= factor;
        }
    }

    public class Square : Shape
    {
        private readonly float side;
        public Square() : this(0)
        {

        }
        public Square(float side)
        {
            this.side = side;
        }
        public override string AsString() => $"A square with side {side}";
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private readonly float transparency;
        private T shape = new T();

        public TransparentShape() : this(0) //The shape gonna be black by default
        {
        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }

    public class ColoredShape<T> : Shape where T : Shape, new()
    {
        private readonly string color;
        private T shape = new T();

        public ColoredShape() : this("black") //The shape gonna be black by default
        {
        }

        public ColoredShape(string color)
        {
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }
}
