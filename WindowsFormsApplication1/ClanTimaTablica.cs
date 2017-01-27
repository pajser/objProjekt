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
        public static ClanTimaPredlozakcs clan;
        public static List<ClanTimaPredlozakcs> clanovi;

        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;

        public static bool dodaj(int idKR, int idT, bool glavni)
        {
            if (glavni) {}
            ClanTimaPredlozakcs novi = new ClanTimaPredlozakcs(idKR, idT, glavni);            
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
        }




        public static List<ClanTimaPredlozakcs> dohvatiClanoveTima(int idTima)
        {
            clanovi = new List<ClanTimaPredlozakcs>();
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
                    clan = new ClanTimaPredlozakcs(idKorisnickiRacun, idTima, vodja);
                    clanovi.Add(clan);
                }
            }
            catch (Exception e)
            {
                return clanovi;//mogu runtime error
            }
            return clanovi;
        }//od dohvatiClanoveTima













    }//od klase
}//od namespace-a
