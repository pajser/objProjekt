using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using handling_projects.Helpers;

namespace handling_projects.Models
{  
    public partial class Tim
    {
        public Tim()
        {


        }

        public Tim(int _idKorisnickiRacun)
        {
            string query = "SELECT * FROM Tim JOIN ClanTIma ON Tim.idTima = ClanTIma.idTima JOIN KorisnickiRacun ON ClanTIma.idKorisnickiRacun = KorisnickiRacun.idKorisnickiRacun WHERE KorisnickiRacun.idKorisnickiRacun = " + _idKorisnickiRacun;
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();

            if (DB.reader.Read())
            {
                idTima = DB.reader.GetInt32(0);
                imeTima = DB.reader.GetString(1);
                naslovAplikacije = DB.reader.GetString(2);
                opisAplikacije = DB.reader.GetString(3);
                idStatusa = DB.reader.GetInt32(4);
                bodovi = DB.reader.GetInt32(5);
            }

            DB.reader.Dispose();
            DB.disposeHelper();

        }
    
        public int idTima { get; private set; }

        [Required(ErrorMessage = "Upisi ime time", AllowEmptyStrings = false )]
        [StringLength(50, ErrorMessage = "Ime tima ne može biti dulje od 50 znakova")]
        [Display(Name = "Ime tima")]
        public string imeTima { get; set; }

        [Required(ErrorMessage = "Upisi naslov aplikacije", AllowEmptyStrings = false)]
        [StringLength(10, ErrorMessage = "Naslov aplikacije ne može biti dulji od 10 znakova")]
        [Display(Name = "Naslov aplikacije")]
        public string naslovAplikacije { get; set; }

        [Required(ErrorMessage = "Upisi opis aplikacije", AllowEmptyStrings = false)]
        [StringLength(500, ErrorMessage = "Opis aplikacije ne može biti dulji od 500 znakova")]
        [Display(Name = "Opis aplikacija")]
        public string opisAplikacije { get; set; }

        public int idStatusa { get; set; }

        public Nullable<int> bodovi { get; set; }

        public bool saveTim(int _idKorisnickiRacun){

            //dodaj Tim
            imeTima = imeTima.Truncate(50);
            naslovAplikacije = naslovAplikacije.Truncate(10);
            opisAplikacije = opisAplikacije.Truncate(500);
            string query1 = "INSERT INTO Tim Values ('" + imeTima + "','" + naslovAplikacije + "','" + opisAplikacije + "', 1 , 0)";
            DBhelper DB1 = new DBhelper(query1);
            int test = DB1.command.ExecuteNonQuery();
            DB1.disposeHelper();

            //naði novo nastali idTima
            string query2 = "SELECT Tim.idTima FROM Tim WHERE Tim.imeTima = '" + imeTima + "' AND Tim.naslovAplikacije = '" + naslovAplikacije + "'";
            DBhelper DB2 = new DBhelper(query2);
            DB2.reader = DB2.command.ExecuteReader();
            if (DB2.reader.Read())
            {
                idTima = DB2.reader.GetInt32(0);
                DB2.reader.Dispose();
                DB2.disposeHelper();
            }
            else
            {
                DB2.reader.Dispose();
                DB2.disposeHelper();
            }
            //makni sve zahtjeve
            string query3 = "DELETE FROM Zahtjev WHERE Zahtjev.idKorisnickiRacun = " + _idKorisnickiRacun;
            DBhelper DB3 = new DBhelper(query3);
            test = DB3.command.ExecuteNonQuery();
            DB3.disposeHelper();
            
            //dodaj ClanTIma
            string query4 = "INSERT INTO ClanTIma Values ('" + _idKorisnickiRacun + "','" + idTima + "','" + true + "')";
            DBhelper DB4 = new DBhelper(query4);
            test = DB4.command.ExecuteNonQuery();

            return true;
        }


        public bool deleteTim()
        {
            //delete ClanTIma
            string query1 = "DELETE FROM ClanTIma WHERE ClanTIma.idTima = " + idTima;
            DBhelper DB1 = new DBhelper(query1);
            int test = DB1.command.ExecuteNonQuery();
            DB1.disposeHelper();

            //delete Tim
            string query2 = "DELETE FROM Tim WHERE Tim.idTima = " + idTima;
            DBhelper DB2 = new DBhelper (query2);
            test = DB2.command.ExecuteNonQuery();
            DB2.disposeHelper();

            return true;
        }


        public List<KorisnickiRacun> teamMembers(int _idTima)
        {
            List<KorisnickiRacun> members = new List<KorisnickiRacun>();

            string query = "SELECT KorisnickiRacun.idKorisnickiRacun FROM Tim JOIN ClanTIma ON Tim.idTima = ClanTIma.idTima JOIN KorisnickiRacun ON ClanTIma.idKorisnickiRacun = KorisnickiRacun.idKorisnickiRacun WHERE Tim.idTima = " +_idTima+" AND ClanTIma.vodja = 0";
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();
            while (DB.reader.Read())
            {
                members.Add(new KorisnickiRacun(DB.reader.GetInt32(0)));
            }
            DB.reader.Dispose();
            DB.disposeHelper();
            return members;

        }

        public List<KorisnickiRacun> teamMembers()
        {
            List<KorisnickiRacun> members = new List<KorisnickiRacun>();

            string query = "SELECT KorisnickiRacun.idKorisnickiRacun FROM Tim JOIN ClanTIma ON Tim.idTima = ClanTIma.idTima JOIN KorisnickiRacun ON ClanTIma.idKorisnickiRacun = KorisnickiRacun.idKorisnickiRacun WHERE Tim.idTima = " + idTima + " AND ClanTIma.vodja = 0";
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();
            while (DB.reader.Read())
            {
                members.Add(new KorisnickiRacun(DB.reader.GetInt32(0)));
            }
            DB.reader.Dispose();
            DB.disposeHelper();
            return members;

        }


        public KorisnickiRacun teamLeader(int _idTima)
        {
            KorisnickiRacun leader;

            string query = "SELECT KorisnickiRacun.idKorisnickiRacun FROM Tim JOIN ClanTIma ON Tim.idTima = ClanTIma.idTima JOIN KorisnickiRacun ON ClanTIma.idKorisnickiRacun = KorisnickiRacun.idKorisnickiRacun WHERE Tim.idTima = " + _idTima + " AND ClanTIma.vodja = 1";
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();

            if (DB.reader.Read())
            {
                leader = new KorisnickiRacun(DB.reader.GetInt32(0));
            }
            else
            {
                leader = new KorisnickiRacun(DB.reader.GetInt32(0));
            }

            DB.reader.Dispose();
            DB.disposeHelper();
            return leader;

        }

        public KorisnickiRacun teamLeader()
        {
            KorisnickiRacun leader;

            string query = "SELECT KorisnickiRacun.idKorisnickiRacun FROM Tim JOIN ClanTIma ON Tim.idTima = ClanTIma.idTima JOIN KorisnickiRacun ON ClanTIma.idKorisnickiRacun = KorisnickiRacun.idKorisnickiRacun WHERE Tim.idTima = " +idTima + " AND ClanTIma.vodja = 1";
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();

            if (DB.reader.Read())
            {
                leader = new KorisnickiRacun(DB.reader.GetInt32(0));
            }
            else
            {
                leader = new KorisnickiRacun(DB.reader.GetInt32(0));
            }

            DB.reader.Dispose();
            DB.disposeHelper();
            return leader;

        }

        public List<KorisnickiRacun> joinRequests(int _idTima)
        {
            List<KorisnickiRacun> requests = new List<KorisnickiRacun>();

            string query = "SELECT KorisnickiRacun.idKorisnickiRacun FROM Tim JOIN Zahtjev ON Tim.idTima = Zahtjev.idTima WHERE Tim.idTima = "+_idTima;
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();

            while (DB.reader.Read())
            {
                requests.Add(new KorisnickiRacun(DB.reader.GetInt32(0)));
            }
            DB.reader.Dispose();
            DB.disposeHelper();
            return requests;

        }

        public List<KorisnickiRacun> joinRequests()
        {
            List<KorisnickiRacun> requests = new List<KorisnickiRacun>();

            string query = "SELECT Zahtjev.idKorisnickiRacun FROM Tim JOIN Zahtjev ON Tim.idTima = Zahtjev.idTima WHERE Tim.idTima = " + idTima;
            DBhelper DB = new DBhelper(query);
            DB.reader = DB.command.ExecuteReader();

            while (DB.reader.Read())
            {
                requests.Add(new KorisnickiRacun(DB.reader.GetInt32(0)));
            }
            DB.reader.Dispose();
            DB.disposeHelper();
            return requests;

        }

        public bool Lock(bool _lock)
        {
            string query;
            if(_lock)
            {
                 query = "UPDATE Tim SET Tim.idStatusa = 2 WHERE Tim.idTima = " +idTima;
            }
            else
            {
                query = "UPDATE Tim SET Tim.idStatusa = 1 WHERE Tim.idTima = " + idTima;
            }
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

    }
}
