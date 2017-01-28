using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class KorisnickiRacunPredlozak
    {
        public int idKorisnickiRacun;
        public string korisnickoIme;
        public string lozinka;
        public string imePrezime;
        public string jmbag;


        public int idKR {
            get {
                return this.idKorisnickiRacun;
                                }
            set{
                 this.idKorisnickiRacun=value;
            }
        }
        public string imeP
        {
            get
            {
                return this.imePrezime;
            }
            set
            {
                this.imePrezime = value;
            }
        }
        public KorisnickiRacunPredlozak(string korisnickoI,string loz, string imeP, string JMBAG)
        {
            this.korisnickoIme = korisnickoI;
            this.lozinka = loz;
            this.imePrezime = imeP;
            this.jmbag = JMBAG;
        }

        public KorisnickiRacunPredlozak(int id, string imeP)
        {
            this.idKorisnickiRacun = id;
            this.korisnickoIme = null;
            this.lozinka = null;
            this.imePrezime = imeP;
            this.jmbag = null;
        }


    }
}
