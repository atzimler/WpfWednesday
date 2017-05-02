using NUnit.Framework;

namespace Z08_AttachingEventHandlers
{
    [TestFixture]
    public class LetsCheckTheEventHandlers
    {
        [Test]
        public void ChainedEventHandlers()
        {
            var m = new MultiplyByTwo();
            var s = new CreateResultStars(m);
            Assert.AreEqual(string.Empty, s.Stars);

            m.Number = 3;
            Assert.AreEqual("******", s.Stars);
        }
    }
}
