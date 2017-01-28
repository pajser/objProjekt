using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class KorisnikZahtjevPredlozak
    {
        public int idKorisnickiRacun;
        public string imePrezime;
        public string poruka;
        public int idKR
        {
            get
            {
                return this.idKorisnickiRacun;
            }
            set
            {
                this.idKorisnickiRacun = value;
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
        public string Por
        {
            get
            {
                return this.poruka;
            }
            set
            {
                this.poruka = value;
            }
        }
        public KorisnikZahtjevPredlozak(int id, string imeP, string por)
        {
            this.idKR = id;
            this.imeP = imeP;
            this.Por = por;
        }




    }
}
