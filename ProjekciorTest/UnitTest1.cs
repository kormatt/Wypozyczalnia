using Moq;
using NUnit.Framework;
using Projekcior.Controllers;
using Projekcior.Models;

namespace ProjekciorTest
{
    [TestFixture(typeof(BossController))]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //var mockSzef = new Mock<Szef>();
            //mockSzef.Setup(szef => szef.Dodaj())
            //    .ReturnsAsync(GetTestSessions());
            Assert.Pass();
        }
    }
}