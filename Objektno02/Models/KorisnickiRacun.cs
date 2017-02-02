using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using handling_projects.Helpers;

namespace handling_projects.Models
{

    public partial class KorisnickiRacun
    {
        public KorisnickiRacun()
        {
           
        }

        public KorisnickiRacun(int _idKorisnickiRacun)
        {
            string query = "SELECT * FROM KorisnickiRacun WHERE KorisnickiRacun.idKorisnickiRacun = " + _idKorisnickiRacun;
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();

            if (DB.reader.Read())
            {
               idKorisnickiRacun = DB.reader.GetInt32(0);
               korisnickoIme = DB.reader.GetString(1);
               imePrezime = DB.reader.GetString(3);
               jmbag = DB.reader.GetString(4);
            }

            DB.reader.Dispose();
            DB.disposeHelper();

        }
    
        public int idKorisnickiRacun { get; private set; }

        [Required(ErrorMessage="Upiši korisnièko ime.", AllowEmptyStrings=false)]
        [Display(Name = "Username")]
        public string korisnickoIme { get; set; }

        [Required(ErrorMessage = "Upiši lozinku.", AllowEmptyStrings=false)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string lozinka { get; set; }

        public string imePrezime { get; private set; }
        public string jmbag { get; private set; }

        [Display(Name = "Zapamti Me")]
        public bool zapamtiMe { get; set; }

        public bool IsValid()
        {
                string query = "SELECT * FROM KorisnickiRacun WHERE KorisnickiRacun.korisnickoIme = '"+korisnickoIme+"' AND KorisnickiRacun.lozinka = '"+lozinka+"'";
                DBhelper DB = new DBhelper(query);
                DB.reader = DB.command.ExecuteReader();
               
                if (DB.reader.Read())
                {
                    this.idKorisnickiRacun = DB.reader.GetInt32(0);
                    this.korisnickoIme = DB.reader.GetString(1);
                    this.imePrezime = DB.reader.GetString(3);
                    this.jmbag = DB.reader.GetString(4);
                    DB.reader.Dispose();
                    DB.command.Dispose();
                    DB.disposeHelper();
                    return true;
                }
                else
                {
                    DB.reader.Dispose();
                    DB.command.Dispose();
                    DB.disposeHelper();
                    return false;
                }
        }

        public bool hasTeam(int _idKorisnickiRacun)
        {
            string query = "SELECT * FROM ClanTIma WHERE ClanTIma.idkorisnickiRacun = " +_idKorisnickiRacun;
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

        public bool leaveTeam(int _idKorisnickiRacun)
        {
            string query = "DELETE FROM ClanTIma WHERE ClanTIma.idkorisnickiRacun = " + _idKorisnickiRacun;
            DBhelper DB = new DBhelper(query);
            int test = DB.command.ExecuteNonQuery();
            DB.disposeHelper();

            if (test > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isLeader(int _idKorisnickiRacun)
        {
            string query = "SELECT * FROM ClanTIma WHERE ClanTIma.idkorisnickiRacun = " + _idKorisnickiRacun+" AND ClanTIma.vodja = 1";
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

    }
}
