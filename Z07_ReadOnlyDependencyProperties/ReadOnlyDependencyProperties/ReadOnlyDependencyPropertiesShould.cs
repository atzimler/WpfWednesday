using NUnit.Framework;
using System;

namespace ReadOnlyDependencyProperties
{
    [TestFixture]
    public class ReadOnlyDependencyPropertiesShould
    {
        [Test]
        public void BeReadableByAnyone()
        {
            var ac = new AddCalculation
            {
                A = 42
            };
            Assert.AreEqual(42, ac.A);
        }

        [Test]
        public void BeWritableByDeclaringClass()
        {
            var ac = new AddCalculation
            {
                A = 13,
                B = 42
            };
            Assert.AreEqual(55, ac.Result);
        }

        [Test]
        public void BeNonWritableByOutsideClasses()
        {
            var ac = new AddCalculation();
            var ex = Assert.Throws<InvalidOperationException>(() => ac.SetValue(AddCalculation.ResultProperty, 13));
            Assert.AreEqual("'Result' property was registered as read-only and cannot be modified without an authorization key.", ex.Message);
        }
    }
}
