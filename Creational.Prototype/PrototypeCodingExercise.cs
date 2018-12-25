using System.IO;
using System.Xml.Serialization;

namespace Creational.Prototype
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(Line));
                s.Serialize(ms, this);
                ms.Position = 0;
                return (Line)s.Deserialize(ms);
            }
        }
    }
}
