using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnit.Tests
{
    [TestFixture]
    public class Inwestycja_tests
    {
        [Test]
        public void wartoscPrzyszla_paramsDouble_Calculated()
        {
            //Arrange
            Inwestycja inw = new Inwestycja();

            //Act
            double kwota = inw.wartoscPrzyszla(1000.00, 0.04);

            //Assert
            Assert.AreEqual(kwota, 1040.00);
        }


        //TODO: sprawdzenie oprocentowanie jako int
        [Test]
        public void wartoscPrzyszla_kwotaDouble_OprocentowanieInt()
        {
            Inwestycja inw = new Inwestycja();

            double kwota = inw.wartoscPrzyszla(1000.00, 1);

            Assert.AreEqual(kwota, 2000.00);
        }

        //TODO: sprawdzenie kwoty jako int
        [Test]
        public void wartoscPrzyszla_kwotaInt_OprocentowanieDouble()
        {
            Inwestycja inw = new Inwestycja();

            double kwota = inw.wartoscPrzyszla(2000, 0.04);

            Assert.AreEqual(kwota, 2080.00);
        }

        //TODO: sprawdzanie obu parametrów int
        [Test]
        public void wartoscPrzyszla_kwotaInt_OprocentowanieInt()
        {
            Inwestycja inw = new Inwestycja();

            double kwota = inw.wartoscPrzyszla(2000, 4);

            Assert.AreEqual(kwota, 10000);
        }

        [Test]
        public void wartoscPrzyszla_kwotaUjemna_Exception()
        {
            Inwestycja inw = new Inwestycja();

            Assert.Throws(Is.TypeOf<ArgumentException>(),
                delegate
                {
                    double kwota = inw.wartoscPrzyszla(-1000.00, 4.0);
                });
        }

        [TestCase(200, 250, 0.25)]
        [TestCase(200, 250.22, 0.2511)]
        [TestCase(200.22, 250, 0.248627)]
        [TestCase(200.22, 250.22, 0.249725)]
        public void wyliczStope_RozneWartosci_Calculated(double kwotaPoczatkowa, double kwotaKoncowa, double wartoscOdniesienia)
        {
            Inwestycja inw = new Inwestycja();

            double kwota = inw.wyliczStope(kwotaPoczatkowa, kwotaKoncowa);

            Assert.AreEqual(kwota, wartoscOdniesienia, 5);
            //TODO: dokładność do 5 miejsc po przecinku
        }

        //TODO: dzielenie przez zero
    }
}
