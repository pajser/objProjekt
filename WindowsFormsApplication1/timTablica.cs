﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class TimTablica
    {
        public static List<TimPredlozak> timovi;
        public static TimPredlozak tim;
        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;

        //metoda "dodaj" prima sve property-je za kreiranje klase TimPredlozak i ubacuje objekt u bazu
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
        }//od dodaj

        //metoda "dohvatiIdTima" dohvaca id Tima na nacin da u bazi trazi tim sa imenom koje je predano kao argument
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
        }//od dohvatiIdTima






        //metoda "dohvatiTimPoIdu" dohvaca Tim (sa svim propertyima) na nacin da u bazi trazi tim sa id-jem koji je predan kao argument
        public static TimPredlozak dohvatiTimPoIdu(int idTima)
        {
            //tim = new TimPredlozak();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Tim WHERE idTima = " + idTima;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idTima = reader.GetInt32(0);
                    string imeTima = reader.GetString(1);
                    string naslovAplikacije = reader.GetString(2);
                    string opisAplikacije = reader.GetString(3);
                    int idStatusa = reader.GetInt32(4);
                    int bodovi = reader.GetInt32(5);
                    tim = new TimPredlozak(imeTima, naslovAplikacije, opisAplikacije, idStatusa, bodovi);
                }
            }
            catch (Exception e)
            {
                return tim;//mogu runtime error
            }
            return tim;
        }//od dohvatiIdTima


        //metoda "dohvatiSveTimove" dohvaca listu svih Timova
        public static List<TimPredlozak> dohvatiSveTimove()
        {
            timovi = new List<TimPredlozak>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Tim";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idTima = reader.GetInt32(0);
                    string imeTima = reader.GetString(1);
                    string naslovAplikacije = reader.GetString(2);
                    string opisAplikacije = reader.GetString(3);
                    int idStatusa = reader.GetInt32(4);
                    int bodovi = reader.GetInt32(5);
                    tim = new TimPredlozak(imeTima, naslovAplikacije, opisAplikacije, idStatusa, bodovi);
                    timovi.Add(tim);
                }
            }
            catch (Exception e)
            {
                return timovi;//mogu runtime error
            }
            return timovi;
        }//od dohvatiSveTimove


        //metoda "izbrisiTim" brise Tim iz baze - prije moraju biti svi clanovi tog tima izbrisani iz relacije ClanTima, baza nece inace dozvolit brisanje
        public static bool izbrisiTim(int idTima)
        {
            //tim = new TimPredlozak(imeTima, naslovAplikacije, opisAplikacije, status, bodovi);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "DELETE FROM Tim WHERE idTima = " + idTima;
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





        public void promjeni() { }
        
    }//klasa

}//namespace



