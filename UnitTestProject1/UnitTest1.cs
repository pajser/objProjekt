using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;
using System.Collections.Generic;

namespace UnitTestProject1

{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize()]
        public void Init()
        {
            //test_za_test source = new test_za_test();
        }


        [TestMethod]
        public void TestMethod_Zbroji()
        {
            //arrange
            int ocekivan = 15;
            test_za_test source = new test_za_test();
            //act
            int dobiven = source.Zbroji(7, 8);
            //assert
            Assert.AreEqual(ocekivan, dobiven, 3, "Nisu dobro zbrojeni");
        }



        //testira metodu za kreiranje connection stringa u klasi test_za_test.cs
        [TestMethod]
        public void TestMethod_QuerryStringBuilder()
        {
            //arrange
            test_za_test proba = new test_za_test();
            string ocekivan = "INSERT INTO KorisnickiRacun Values ('os1234', 'loz93475', 'Otto Singer', '009409565545')";
            string usernam_test = "os1234";
            string password_test = "loz93475";
            string nameSurnam_test = "Otto Singer";
            string jmbag_test = "009409565545";
            //act
            string dobiven = proba.QuerryStringBuilder(usernam_test, password_test, nameSurnam_test, jmbag_test);
            //assert
            Assert.AreEqual(ocekivan, dobiven);// true, "Upiti su isti - SQL je case insensitive");
        }



        ////testira metodu za kreiranje connection stringa u klasi KorisnickiRacunTablica.cs, ISTA METODA KO GORE
        //[TestMethod]
        //public void TestMethod_QuerryStringBuilder_KorRacTabl()
        //{
        //    //arrange
        //    KorisnickiRacunTablica testna = new KorisnickiRacunTablica();
        //    string ocekivan = "INSERT INTO KorisnickiRacun Values ('os1234', 'loz93475', 'Otto Singer', '009409565545')";
        //    string usernam_test = "os1234";
        //    string password_test = "loz93475";
        //    string nameSurnam_test = "Otto Singer";
        //    string jmbag_test = "009409565545";
        //    //act
        //    string dobiven = testna.QuerryStringBuilder(usernam_test, password_test, nameSurnam_test, jmbag_test);
        //    //assert
        //    Assert.AreEqual(ocekivan, dobiven);// true, "Upiti su isti - SQL je case insensitive");
        //}



        ////testira metodu DohvatiKorisnikaPoIdu iz klase test_za_test.cs
        //[TestMethod]
        //public void TestMethod_DohvatiKorisnikaPoIdu()
        //{
        //    //arrange
        //    KorisnickiRacunPredlozak ocekivan = new KorisnickiRacunPredlozak(1, "admin", "123", "Admin Adminovic", "00463546445");
        //    test_za_test test_za_test = new test_za_test();
        //    //act
        //    KorisnickiRacunPredlozak dobiven = test_za_test.DohvatiKorisnikaPoIdu(1);
        //    //assert
        //    Assert.AreEqual(ocekivan, dobiven);
        //    }
        //}



        ////testira metodu DohvatiKorisnikaPoIdu iz klase test_za_test.cs
        //[TestMethod]
        //public void TestMethod_DohvatiSveKorisnike()
        //{
        //    //arrange
        //    KorisnickiRacunPredlozak ocekivan = new KorisnickiRacunPredlozak(1, "admin", "123", "Admin Adminovic", "00463546445");
        //    List<KorisnickiRacunPredlozak> ocekivani = new List<KorisnickiRacunPredlozak>();
        //    test_za_test test_za_test = new test_za_test();
        //    //act
        //    List<KorisnickiRacunPredlozak> dobiveni = test_za_test.DohvatiSveKorisnike();
        //    //assert
        //    Assert.AreEqual(ocekivani, dobiveni);
        //}








    }//test klasa
}//namespace
