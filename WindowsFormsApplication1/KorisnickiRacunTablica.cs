﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class KorisnickiRacunTablica
    {
        public static List<KorisnickiRacunPredlozak> korisnici;
        public static KorisnickiRacunPredlozak korisnik;
        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;

        //dodaje novog korisnika u bazu, prima sve propertyje potrebne za objekt tj za relaciju
        public static bool dodajKorisnika(string user, string pass, string imePrezime, string jmbag)
        {
            korisnik = new KorisnickiRacunPredlozak(user, pass, imePrezime, jmbag); 
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO KorisnickiRacun Values ('" + korisnik.korisnickoIme + "', '" + korisnik.lozinka + "', '" + korisnik.imePrezime + "', '" + korisnik.jmbag + "')";
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
        }//dodaj korisnika


        //ovo bi trebala biti zapravo funkcija za "provjeriJelRegistriranKorisnik", i ako je onda pozvati [tek treba napraviti] funkciju za ulogiravanje koja na neki nacin sprema cookie za session id-a korisnika il tak nes, vidjet cemo jel to treba
        public static KorisnickiRacunPredlozak UlogirajKorisnika(string user, string pass)
        {
            korisnik = new KorisnickiRacunPredlozak(user, pass, null, null);
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM KorisnickiRacun WHERE korisnickoIme = '" + korisnik.korisnickoIme + "' AND lozinka = '" + korisnik.lozinka + "'";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                //if (reader.HasRows == false)  //ovo ne valja jer vracas objekt, a ne postoji null objekt pa baca error - bug
                //{
                //    return null;
                //}

                while (reader.Read())
                {
                    korisnik.idKorisnickiRacun = reader.GetInt32(0);
                    korisnik.korisnickoIme = reader.GetString(1);
                    korisnik.lozinka = reader.GetString(2);
                    korisnik.imePrezime = reader.GetString(3);
                    korisnik.jmbag = reader.GetString(4);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return korisnik;
        }//ulogiraj korisnika

        //dohvaca sve detalje korisnika po id-u koji se predaje kao argument
        public static KorisnickiRacunPredlozak dohvatiKorisnikaPoIdu(int idKorisnickiRacun)
        {
            //tim = new TimPredlozak();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM KorisnickiRacun WHERE idKorisnickiRacun = " + idKorisnickiRacun;
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idKorisnickiRacun = reader.GetInt32(0);
                    string korisnickoIme = reader.GetString(1);
                    string lozinka = reader.GetString(2);
                    string imePrezime = reader.GetString(3);
                    string jmbag = reader.GetString(4);

                    korisnik = new KorisnickiRacunPredlozak(korisnickoIme, lozinka, imePrezime, jmbag);
                }
            }
            catch (Exception e)
            {
                return korisnik;//mogu runtime error
            }
            return korisnik;
        }//od dohvatiKorisnikaPoIdu


        //dohvaca listu svih korisnika (koristit ce se kad vodja tima primjerice salje zahtjev za pridruzenje u tim nekom liku, trebat ce vidjet izlistane sve korisnike)
        //trebalo bi mozda jos vidjet kak da dohvaca samo korisnike koji nemaju tim
        public static List<KorisnickiRacunPredlozak> dohvatiSveKorisnike()
        {
            korisnici = new List<KorisnickiRacunPredlozak>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM KorisnickiRacun";
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idKorisnickiRacun = reader.GetInt32(0);
                    string korisnickoIme = reader.GetString(1);
                    string lozinka = reader.GetString(2);
                    string imePrezime = reader.GetString(3);
                    string jmbag = reader.GetString(4);
                    korisnik = new KorisnickiRacunPredlozak(korisnickoIme, lozinka, imePrezime, jmbag);
                    korisnici.Add(korisnik);
                }
            }
            catch (Exception e)
            {
                return korisnici;//mogu runtime error
            }
            return korisnici;
        }//od dohvatiSveKorisnike






        //NEMAM POJMA KAJ JE OVO DOLE AL ME STRAH IZBRISAT LOL XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        //public void dodaj(string korisnickoI, string loz, string imeP, string JMBAG)
        //{
        //    KorisnickiRacunPredlozak novi = new KorisnickiRacunPredlozak(korisnickoI, loz, imeP, JMBAG);
        //    //this.korisnici.Add(novi);
        //    
        //}



    }//klasa
}//namespace
    
    
