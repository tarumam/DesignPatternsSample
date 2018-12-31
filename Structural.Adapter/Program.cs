using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Structural.Adapter
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            if (start == null)
            {
                throw new ArgumentNullException(paramName: nameof(start));
            }
            if (end == null)
            {
                throw new ArgumentNullException(paramName: nameof(end));
            }
            Start = start;
            End = end;
        }
    }

    public class VectorObject : Collection<Line>
    {

    }
    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : Collection<Point>
    {
        private static int count;
        public LineToPointAdapter(Line line)
        {
            Console.WriteLine($"{++count}: Generation points for line [{line.Start.X},{line.Start.Y}]-[{line.End.X},{line.End.Y}]");

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    Add(new Point(x, top));
                }
            }
        }

    }

    internal class Program
    {
        private static readonly List<VectorObject> VectorObjects = new List<VectorObject>
        {
            new VectorRectangle(1,1,10,10),
            new VectorRectangle(3,4,6,6)
        };

        public static void DrawPoint(Point p)
        {
            Console.Write(".");
        }

        private static void Draw()
        {
            foreach (var vo in VectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ToList().ForEach(DrawPoint);
                }
            }            
        }

        private static void Main(string[] args)
        {
            Draw();
            Draw(); // It generates twice the same bunch of information, lets try caching (see with caching file)
            Console.ReadKey();
        }
    }
}
