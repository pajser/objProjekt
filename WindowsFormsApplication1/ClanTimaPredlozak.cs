using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ClanTimaPredlozak
    {
        public int idKorisnickiRacun;
        public int idTima;
        public bool vodja;
        public ClanTimaPredlozak(int idKR,int idT,bool glavni)
        {
            this.idKorisnickiRacun = idKR;
            this.idTima = idT;
            this.vodja = glavni;
        }
    }
}
