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
        Inwestycja inw;

        [OneTimeSetUp]
        public void utworzObiekt()
        {
            inw = new Inwestycja();
        }

        [OneTimeTearDown]
        public void posprzataj()
        {
            inw = null;
        }
        [Test]
        public void wartoscPrzyszla_paramsDouble_Calculated()
        {
            double kwota = inw.wartoscPrzyszla(1000.00, 0.04, 1);

            Assert.AreEqual(kwota, 1040.00);
        }

        [Test]
        public void wartoscPrzyszla_kwotaInt_OprocentowanieDouble()
        {
            double kwota = inw.wartoscPrzyszla(1000, 0.04, 3);

            Assert.AreEqual(kwota, 1124.864);
        }

        [Test]
        public void wartoscPrzyszla_kwotaDouble_OprocentowanieInt()
        {
            double kwota = inw.wartoscPrzyszla(1000.00, 1, 2);

            Assert.AreEqual(kwota, 4000.00);
        }

        [Test]
        public void wartoscPrzyszla_kwotaInt_OprocentowanieInt()
        {
            double kwota = inw.wartoscPrzyszla(500, 1, 1);

            Assert.AreEqual(kwota, 1000.00);
        }
        [Ignore("Wiemy, że działa")]
        [Test]
        public void wartoscPrzyszla_kwotaUjemna_Exception()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>(),
                delegate
                {
                    double kwota = inw.wartoscPrzyszla(-1000.00, 4.0, 1);
                });
        }

        [Test]
        public void wartoscPrzyszla_PrzeciazenieWartosci_Exception()
        {
            var ex = Assert.Throws<OverflowException>(
                () => inw.wartoscPrzyszla(Double.MaxValue, 0.04, 999));

            Assert.That(ex.Message == "Parametry spoza dopuszczalnych zakresów");
        }

        [TestCase(200, 250, 1, 0.25)]
        [TestCase(200, 300, 5, 0.84471771198)]
        [TestCase(200, 250.22, 1, 0.2511)]
        [TestCase(200.22, 250, 1, 0.248627)]
        [TestCase(200.22, 250.22, 1, 0.249725)]
        public void wyliczStope_RozneWartosci_Calculated(double kwotaPoczatkowa, double kwotaKoncowa, int okresy, double wartoscOdniesienia)
        {
            double kwota = inw.wyliczStope(kwotaPoczatkowa, kwotaKoncowa, okresy);

            Assert.AreEqual(kwota, wartoscOdniesienia, 5);
        }

        [Test]
        public void wyliczStope_dzieleniePrzezZero_Exception()
        {
            Assert.Throws(Is.TypeOf<ArithmeticException>()
                .And.Message.EqualTo("Kwota wyjściowa nie może być równa 0"),
                delegate
                {
                    double kwota = inw.wyliczStope(0.00, 500.00, 1);
                });
        }
    }
}
