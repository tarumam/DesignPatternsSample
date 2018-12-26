using Creational.Singleton;
using NUnit.Framework;

namespace Creational.Singleton.Test
{
    [TestFixture]
    public class SingletonImplementationTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDataBase.Instance;
            var db2 = SingletonDataBase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDataBase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        }
    }
}