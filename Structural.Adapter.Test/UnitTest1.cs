using NUnit.Framework;
using Structural.Adapter;

namespace Tests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var sq = new Square { Side = 11 };
            var adapter = new SquareToRectangleAdapter(sq);
            Assert.That(adapter.Area(), Is.EqualTo(121));
        }
    }
}