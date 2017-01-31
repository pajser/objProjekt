using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace UnitTestProject1

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //priprema
            int ocekivan = 15;

            int dobiven = test_za_test.zbroji(7, 8);

            Assert.AreEqual(ocekivan, dobiven, 3, "Nisu dobro zbrojeni");
        }

        [TestMethod]
        public void TestMethod_ConnectionString()
        {
            //priprema
            string ocekivan = "INSERT INTO KorisnickiRacun Values ('os1234', 'loz93475', 'Otto Singer', '009409565545')";
            string usernam_test = "os1234";
            string password_test = "loz93475";
            string nameSurnam_test = "Otto Singer";
            string jmbag_test = "009409565545";
            //KorisnickiRacunTablica tabl = new KorisnickiRacunTablica();
            string dobiven = test_za_test.DodajKorisnika_Testiranje(usernam_test, password_test, nameSurnam_test, jmbag_test);

            Assert.AreEqual(ocekivan, dobiven);// true, "Upiti su isti - SQL je case insensitive");

        }
    }
}
