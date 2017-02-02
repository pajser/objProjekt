using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using handling_projects.Helpers;

namespace handling_projects.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zahtjev
    {
        public int idKorisnickiRacun { get; set; }
        public int idTima { get; set; }
        public bool iniciraKorisnik { get; set; }
        public string poruka { get; set; }

        public bool requestSent(int _idKorisnickiRacun, int _idTima) 
        {
            string query = "SELECT DISTINCT Zahtjev.idKorisnickiRacun, Zahtjev.idTima FROM Zahtjev WHERE Zahtjev.idkorisnickiRacun = " + _idKorisnickiRacun+" AND Zahtjev.idTima = "+_idTima+" AND Zahtjev.iniciraKorisnik = 1";
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();
            if (DB.reader.Read())
            {
                DB.reader.Dispose();
                DB.disposeHelper();
                return true;
            }
            else
            {
                DB.reader.Dispose();
                DB.disposeHelper();
                return false;
            }
        }

        public bool send(int _idKorisnickiRacun, int _idTima)
        {
            string query1 = "INSERT INTO Zahtjev VALUES (" + _idKorisnickiRacun + " , " + _idTima + " , 1 , 'Poruka' )";
            DBhelper DB1 = new DBhelper(query1);
            int test = DB1.command.ExecuteNonQuery();
            DB1.disposeHelper();
            if (test > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool accept(int _idKorisnickiRacun, int _idTima)
        {
            string query1 = "DELETE FROM Zahtjev WHERE Zahtjev.idKorisnickiRacun = " + _idKorisnickiRacun;
            DBhelper DB1 = new DBhelper(query1);
            int test = DB1.command.ExecuteNonQuery();
            DB1.disposeHelper();
            if (test > 0)
            {
                string query2 = "INSERT INTO ClanTIma VALUES (" + _idKorisnickiRacun + " , " + _idTima + " , 0 )";
                DBhelper DB2 = new DBhelper(query2);
                test = DB2.command.ExecuteNonQuery();
                DB2.disposeHelper();
                if (test > 0)
                {
                    return true;
                }

            }

            return false;

        }

        public bool decline(int _idKorisnickiRacun, int _idTima)
        {
            string query1 = "DELETE FROM Zahtjev WHERE Zahtjev.idKorisnickiRacun = " + _idKorisnickiRacun;
            DBhelper DB1 = new DBhelper(query1);
            int test = DB1.command.ExecuteNonQuery();
            DB1.disposeHelper();
            if (test > 0)
            {
                return true;

            }
            return false;

        }
    
        public virtual KorisnickiRacun KorisnickiRacun { get; set; }
        public virtual Tim Tim { get; set; }
    }
}
