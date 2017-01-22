using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class KorisnickiRacunPredlozak
    {
        public int idKorisnickiRacun;
        public string korisnickoIme;
        public string lozinka;
        public string imePrezime;
        public string jmbag;

        public KorisnickiRacunPredlozak(string korisnickoI,string loz, string imeP, string JMBAG)
        {
            this.korisnickoIme = korisnickoI;
            this.lozinka = loz;
            this.imePrezime = imeP;
            this.jmbag = JMBAG;
        }
    }
}
