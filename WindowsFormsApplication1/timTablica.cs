using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class TimTablica
    {
        public List<TimPredlozak> timovi;
        public static TimPredlozak tim;
        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;

        public static bool dodaj(string imeTima, string naslovAplikacije, string opisAplikacije, int status, int bodovi ) {

            tim = new TimPredlozak(imeTima, naslovAplikacije, opisAplikacije, status, bodovi);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Tim Values ('" + tim.imeTima + "', '" + tim.naslovAplikacije + "', '" + tim.opisAplikacije + "', " + tim.idStatusa + ", " + tim.bodovi + ")";
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


        public static int dohvatiIdTima(string nazivTima)
        {
            int idTima = 0;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT idTima FROM Tim WHERE imeTima = '" + nazivTima + "'";
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
        }//ulogiraj korisnika
















        public void promjeni() { }
        public void makni() { }
        public void dohvati() { }
    }//klasa

}//namespace



