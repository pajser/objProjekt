using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    class timTablica
    {
        public List<TimPredlozak> timovi;

        public void dodaj(string imeTima, string naslovAplikacije, string opisAplikacije) {
            TimPredlozak novi = new TimPredlozak(imeTima,naslovAplikacije,opisAplikacije);
            this.timovi.Add(novi);

            //tu ide dodavanje i u bazu     
        }

        public void promjeni() { }
        public void makni() { }
        public void dohvati() { }
    }
}
