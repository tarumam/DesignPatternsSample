using Autofac;
using Creational.Singleton.SingletonDependencyInjection;
using NUnit.Framework;

namespace Creational.SingletonDI.Test
{
    [TestFixture]
    public class SingletonImplementationTests
    {

        [Test]
        public void ConfigurablePopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());

            var names = new[] { "alpha", "gamma" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();

            //Autofac Dependency injection returning a singleton due this configuration
            //cb.RegisterType<DummyDatabase>().As<IDatabase>().SingleInstance();

            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();
            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
                var names = new[] { "Tokyo", "Sao Paulo" };
                Assert.That(rf.GetTotalPopulation(names), Is.EqualTo(33200000 + 17700000));


                Assert.That(rf.GetPopulation("Tokyo"), Is.EqualTo(33200000));

            }
        }
    }
}
