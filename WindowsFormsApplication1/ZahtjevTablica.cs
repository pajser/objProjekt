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
                System.Windows.MessageBox.Show("korisnik je već pozvan u tim");
                return false;
            }
            return false;
        }//od dodaj zahtjev



        //metoda "dohvatiZahtjeveZaTim" dohvaca listu svih Zahtjeva koji su upuceni jednom timu (id targetiranog tima je predan kao argument)
        public static List<ZahtjevPredlozak> DohvatiZahtjeveZaTim(int idTima)
        {
            zahtjevi = new List<ZahtjevPredlozak>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Zahtjev WHERE idTima = " + idTima;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idKorisnickiRacun = reader.GetInt32(0);
                    idTima = reader.GetInt32(1);
                    bool inic = reader.GetBoolean(2);
                    string por = reader.GetString(3);
                    zahtjev = new ZahtjevPredlozak(idKorisnickiRacun, idTima, inic, por);
                    zahtjevi.Add(zahtjev);
                }
            }
            catch (Exception e)
            {
                return zahtjevi;//mogu runtime error
            }
            return zahtjevi;
        }//od dohvatiZahtjeveZaTim


        
        //metoda "izbrisiZahtjev" brise zahtjev iz baze - to se izvrsava nakon sto je korisnik dodan u tim tj. konkretno u tablicu ClanTima (ne smije biti i zahtjev i clanTima postojec istovremeno)
        public static bool IzbrisiZahtjev(int idKR, int idT, bool inic, string por)
        {
            //ZahtjevPredlozak novi = new ZahtjevPredlozak(idKR, idT, inic, por);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            //command.CommandText = "DELETE FROM Zahtjev WHERE idKorisnickiRacun = " + novi.idKorisnickiRacun + " AND idTima = " + novi.idTima;
            command.CommandText = "DELETE FROM Zahtjev WHERE idKorisnickiRacun = " + idKR + " AND idTima = " + idT;
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
