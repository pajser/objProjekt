using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    class TimPredlozak
    {
        public int idTima;
        public string imeTima;
        public string naslovAplikacije;
        public string opisAplikacije;
        public int idStatusa;
        public int bodovi;

        public TimPredlozak(string imeT,string naslovA,string opisA, int status, int bodov)
        {
            this.imeTima = imeT;
            this.naslovAplikacije = naslovA;
            this.opisAplikacije = opisA;
            this.idStatusa = status;
            this.bodovi = bodov;
        }
    }
}
