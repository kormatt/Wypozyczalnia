using NUnit.Framework;
using Projekcior.Models;

namespace Testy {
    [TestFixture(typeof(Klient))]

    public class Tests<Accommodatable> where Accommodatable : IAccommodatable, new() {


        [SetUp]
        public void Setup() {
            //tested = new Accommodatable();
        }

        //[Test]
        //public void ShouldEmailBeValidatedd() {
        //    //given
        //    string expectedEmail = "witkowski213@gmail.com";
        //    string expectedPassword = "nszymbor221";
        //    string expectedName = "Kamil";
        //    string expectedSurname = "Nowak";
        //    string expectedAddress = "Krakowska 55a";

        //    //when
        //    tested.Accommodate("witkowski213@gmail.com\nszymbor221\nKamil1\nNowak\nKrakowska 55a");

        //    //then
        //    Assert.AreEqual(null, tested);
        //    Assert.AreEqual(expectedEmail, tested.email);
        //    Assert.AreEqual(expectedPassword, tested.haslo);
        //    Assert.AreEqual(expectedName, tested.imie);
        //    Assert.AreEqual(expectedSurname, tested.nazwisko);
        //    Assert.AreEqual(expectedAddress, tested.adres);
        //}

        [Test]
        public void ShouldEmailBeValidated()
        {
            //given
            string expectedEmail = "witkowski213@gmail.com";

            //when
            bool result = Klient.ValidateEmail(expectedEmail);

            //then
            Assert.IsTrue(result);

        }

        [Test]
        public void ShouldEmailNotBeValidated()
        {
            //given
            string expectedEmail = "witkowski213gmail.com";

            //when
            bool result = Klient.ValidateEmail(expectedEmail);

            //then
            Assert.IsTrue(result);
        }

        //[TestCaseSource("accommodateTestCasesPesel")]
        //public void AccommodateTestPesel(IAccommodatable expected, long nrpesel) {
        //    tested.AccommodateLong(nrpesel);
        //    Assert.AreEqual(expected.pesel, tested.pesel);
        //}


        //[TestCaseSource("accommodateTestCasesInt")]
        //public void AccommodateTestInt(IAccommodatable expected, int number) {
        //    tested.AccommodateInt(number);
        //    Assert.AreEqual(expected.nrTelefonu, tested.nrTelefonu);
        //}

    }
}