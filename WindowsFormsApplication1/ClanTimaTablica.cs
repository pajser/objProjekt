using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ClanTimaTablica
    {
        public List<ClanTimaPredlozakcs> povezani;

        public void dodaj(int idKR, int idT, bool glavni)
        {
            ClanTimaPredlozakcs novi = new ClanTimaPredlozakcs(idKR, idT, glavni);
            this.povezani.Add(novi);

            //tu ide dodavanje i u bazu   
        }

    }
}
