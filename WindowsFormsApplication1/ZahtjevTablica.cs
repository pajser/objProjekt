using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ZahtjevTablica
    {
        public static ZahtjevPredlozak zahtjev;
        public static List<ZahtjevPredlozak> zahtjevi;
        public static List<KorisnikZahtjevPredlozak> korZahtjevi;
        public static KorisnikZahtjevPredlozak korZahtjev;

        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;



        //metoda "dodaj" prima sve property-je za kreiranje klase ZahtjevPredlozak i ubacuje objekt u bazu
        public static bool DodajZahtjev(int idKR, int idT, bool inic, string por)
        {
            ZahtjevPredlozak novi = new ZahtjevPredlozak(idKR, idT, inic, por);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Zahtjev values (" + novi.idKorisnickiRacun + ", " + novi.idTima + ", '" + novi.iniciraKorisnik + "', '" + novi.poruka + "')";
            try
            {
                conn.Open();
                int test = command.ExecuteNonQuery();
                if (test > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Zahtjev je već poslan.");
                return false;
            }
            return false;
        }//od dodaj zahtjev



        //metoda "dohvatiZahtjeveZaTim" dohvaca listu svih Zahtjeva koji su upuceni jednom timu (id targetiranog tima je predan kao argument)
        public static List<KorisnikZahtjevPredlozak> DohvatiZahtjeveZaTim(int idTima)
        {
            korZahtjevi = new List<KorisnikZahtjevPredlozak>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT KorisnickiRacun.idKorisnickiRacun, KorisnickiRacun.imePrezime, Zahtjev.poruka FROM Zahtjev LEFT JOIN KorisnickiRacun ON Zahtjev.idKorisnickiRacun = KorisnickiRacun.idKorisnickiRacun WHERE Zahtjev.idTima = " + idTima  + " AND iniciraKorisnik = 1";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idKorisnickiRacun = reader.GetInt32(0);
                    string imePrezime = reader.GetString(1);
                    string poruka = reader.GetString(2);

                    korZahtjev = new KorisnikZahtjevPredlozak(idKorisnickiRacun, imePrezime, poruka);
                    korZahtjevi.Add(korZahtjev);
                }
            }
            catch (Exception e)
            {
                return korZahtjevi;//mogu runtime error
            }
            return korZahtjevi;
        }//od dohvatiZahtjeveZaTim


        
        //metoda "izbrisiZahtjev" brise zahtjev iz baze - to se izvrsava nakon sto je korisnik dodan u tim tj. konkretno u tablicu ClanTima (ne smije biti i zahtjev i clanTima postojec istovremeno)
        public static bool IzbrisiZahtjev(int idKR, int idT)
        {
            //ZahtjevPredlozak novi = new ZahtjevPredlozak(idKR, idT, inic, por);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            string tekst = "DELETE FROM Zahtjev WHERE ";
            if (idKR > 0)
            {
                string tekst1 = "idKorisnickiRacun = " + idKR;
                tekst += tekst1;
            }
            if (idKR>0 && idT>0)
            {
                string tekst2 = " AND ";
                tekst += tekst2;
            }
            if (idT > 0)
            {
                string tekst3 = "idTima = " + idT;
                tekst += tekst3;
            }
            command.CommandText = tekst;
            try
            {
                conn.Open();
                int test = command.ExecuteNonQuery();
                if (test > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }//od izbrisi zahtjev





    }//od klase
}//od namespacea
