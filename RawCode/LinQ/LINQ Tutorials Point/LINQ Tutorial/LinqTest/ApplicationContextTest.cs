using NUnit.Framework;
using LINQ_Tutorial.Repository;

namespace LinqTest
{
    [TestFixture]
    class AppContextTest
    {

        [Test]
        public void MustContainConnectionString()
        {
            //TODO: Test can't find configuration keys. How to handle that?
            ApplicationContext ctx = new ApplicationContext();

            Assert.That(ctx.ConnectionString, Is.Not.Null);
            Assert.That(ctx.ConnectionString, Is.Not.Empty);
        }
    }
}