using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class KorisnickiRacunTablica
    {
        public List<KorisnickiRacunPredlozak> korisnici;

        public void dodaj(string korisnickoI, string loz, string imeP, string JMBAG)
        {
            KorisnickiRacunPredlozak novi = new KorisnickiRacunPredlozak(korisnickoI, loz, imeP, JMBAG);
            this.korisnici.Add(novi);

            //tu ide dodavanje i u bazu   
        }
    }
    }
