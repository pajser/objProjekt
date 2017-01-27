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

        public static bool dodaj(int idKR, int idT, bool glavni)
        {
            if (glavni) {}//ZA KAJ JE OVO TU BILO?!?!?!xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxXXX OVO JE SAMO DA PRIMJETIS KOMENTAR
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
        public static List<ClanTimaPredlozak> dohvatiClanoveTima(int idTima)
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













    }//od klase
}//od namespace-a
