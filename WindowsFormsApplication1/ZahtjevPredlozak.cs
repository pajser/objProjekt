using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ZahtjevPredlozak
    {
        public int idKorisnickiRacun;
        public int idTima;
        public bool iniciraKorisnik;
        public string poruka;
        public ZahtjevPredlozak(int idKR, int idT, bool ini, string por)
        {
            this.idKorisnickiRacun = idKR;
            this.idTima = idT;
            this.iniciraKorisnik = ini;
            this.poruka = por;
        }

    }
}
