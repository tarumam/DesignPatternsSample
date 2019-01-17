using NUnit.Framework;
using Structural.Composite;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var singleValue = new SingleValue { Value = 11 };
            var otherValues = new ManyValues();

            otherValues.Add(22);
            otherValues.Add(33);
            Assert.That(new List<IValueContainer> { singleValue, otherValues }.Sum(), Is.EqualTo(66));
        }
    }
}