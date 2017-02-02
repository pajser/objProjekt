using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class test_za_test
    {
        public static int i = 15;

        public int Zbroji(int x, int y)
        {
            return x + y+2;
        }

        public string QuerryStringBuilder(string user, string pass, string imePrezime, string jmbag)
        {
            string connectionStringTest = "INSERT INTO KorisnickiRacun Values ('" + user + "', '" + pass + "', '" + imePrezime + "', '" + jmbag + "')";
            return connectionStringTest;
        }





        //public static KorisnickiRacunPredlozak korisnik;
        ////zbog connStr puca, tu uvijek javlja gresku da se referenca nije na instanci klase?!?!
        //private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;



        //public KorisnickiRacunPredlozak DohvatiKorisnikaPoIdu(int idKorisnickiRacun)
        //{
        //    KorisnickiRacunPredlozak korisnik = new KorisnickiRacunPredlozak(0, null, null, null, null);
        //    SqlConnection conn = new SqlConnection(connStr);
        //    SqlCommand command = conn.CreateCommand();
        //    command.CommandText = "SELECT * FROM KorisnickiRacun WHERE idKorisnickiRacun = " + idKorisnickiRacun;
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            idKorisnickiRacun = reader.GetInt32(0);
        //            string korisnickoIme = reader.GetString(1);
        //            string lozinka = reader.GetString(2);
        //            string imePrezime = reader.GetString(3);
        //            string jmbag = reader.GetString(4);

        //            korisnik = new KorisnickiRacunPredlozak(korisnickoIme, lozinka, imePrezime, jmbag);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return korisnik;
        //    }
        //    return korisnik;
        //}//od dohvatiKorisnikaPoIdu



        //public List<KorisnickiRacunPredlozak> DohvatiSveKorisnike()
        //{
        //    KorisnickiRacunPredlozak korisnik = new KorisnickiRacunPredlozak(0, null, null, null, null);
        //    List<KorisnickiRacunPredlozak> korisnici = new List<KorisnickiRacunPredlozak>();
        //    SqlConnection conn = new SqlConnection(connStr);
        //    SqlCommand command = conn.CreateCommand();
        //    command.CommandText = "SELECT * FROM KorisnickiRacun";
        //    try
        //    {
        //        conn.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            int idKorisnickiRacun = reader.GetInt32(0);
        //            string korisnickoIme = reader.GetString(1);
        //            string lozinka = reader.GetString(2);
        //            string imePrezime = reader.GetString(3);
        //            string jmbag = reader.GetString(4);
        //            korisnik = new KorisnickiRacunPredlozak(korisnickoIme, lozinka, imePrezime, jmbag);
        //            korisnici.Add(korisnik);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return korisnici;
        //    }
        //    return korisnici;
        //}//od dohvatiSveKorisnike






    }//od klase
}//od namespacea
