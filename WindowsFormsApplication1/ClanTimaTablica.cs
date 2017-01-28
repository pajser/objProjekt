using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ClanTimaTablica
    {
        public static ClanTimaPredlozak clan;
        public static List<ClanTimaPredlozak> clanovi;

        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;



        //dodaje u ClanTima "vezu" izmedu postojeceg korisnika i tima
        public static bool DodajClanTima(int idKR, int idT, bool glavni)
        {
            ClanTimaPredlozak novi = new ClanTimaPredlozak(idKR, idT, glavni);         
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO ClanTIma values (" + novi.idKorisnickiRacun + ", " + novi.idTima + ", '" + novi.vodja + "')";
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
        }//od dodaj



        //metoda "dohvatiClanoveTima" dohvaca listu svih -ClanTima- koji su clanovi tima ciji je argument kod poziva. Nakon toga korisni uzastopno dohvacanje iz KorisnickiRacunTablica po listi idejeva koje tu dobis
        public static List<ClanTimaPredlozak> DohvatiClanoveTima(int idTima)
        {
            clanovi = new List<ClanTimaPredlozak>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM ClanTIma WHERE idTima = " + idTima;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idKorisnickiRacun = reader.GetInt32(0);
                    idTima = reader.GetInt32(1);
                    bool vodja = reader.GetBoolean(2);
                    clan = new ClanTimaPredlozak(idKorisnickiRacun, idTima, vodja);
                    clanovi.Add(clan);
                }
            }
            catch (Exception e)
            {
                return clanovi;//mogu runtime error
            }
            return clanovi;
        }//od dohvatiClanoveTima


        //metoda "dohvatiIdTima" dohvaca id Tima u relaciji korisnik-tim s ulaznim argumentom ID korisnika
        public static int DohvatiIdTima(int idKorisnickiRacun)
        {
            int idTima = 0;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT idTima FROM ClanTIma WHERE idKorisnickiRacun = '" + idKorisnickiRacun.ToString() + "'";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idTima = reader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                return -1;
            }
            return idTima;
        }//od dohvatiIdTima




        //metoda "izbrisiClanaTima" brise clana tima iz baze, osoba postoji jos u sustavo isto kao sto postoji i tim
        public static bool IzbrisiClanaTima(int idKorisnickiRacun, int idTima)
        {
            //tim = new TimPredlozak(imeTima, naslovAplikacije, opisAplikacije, status, bodovi);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
          
            command.CommandText = "DELETE FROM ClanTima WHERE idKorisnickiRacun = " + idKorisnickiRacun + " AND idTima = " + idTima;
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
        }//od dodaj

        public static bool IzbrisiClanoveTima(int idTima)
        {
            //tim = new TimPredlozak(imeTima, naslovAplikacije, opisAplikacije, status, bodovi);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();

            command.CommandText = "DELETE FROM ClanTima WHERE idTima = " + idTima;
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
        }//od dodaj







    }//od klase
}//od namespace-a
