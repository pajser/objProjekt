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


        public int IdTima
        {
            get
            {
                return this.idTima;
            }
            set
            {
                this.idTima = value;
            }
        }
        public string ImeTima
        {
            get
            {
                return this.imeTima;
            }
            set
            {
                this.imeTima = value;
            }
        }
        public string NaslovAplikacije
        {
            get
            {
                return this.naslovAplikacije;
            }
            set
            {
                this.naslovAplikacije = value;
            }
        }
        public string OpisAplikacije
        {
            get
            {
                return this.opisAplikacije;
            }
            set
            {
                this.opisAplikacije = value;
            }
        }
        public int IdStatusa
        {
            get
            {
                return this.idStatusa;
            }
            set
            {
                this.idStatusa = value;
            }
        }


        public TimPredlozak(string imeT,string naslovA,string opisA, int status, int bodov)
        {
            this.imeTima = imeT;
            this.naslovAplikacije = naslovA;
            this.opisAplikacije = opisA;
            this.idStatusa = status;
            this.bodovi = bodov;
        }
        public TimPredlozak(int idTim,string imeT, string naslovA, string opisA, int status, int bodov)
        {
            this.idTima = idTim;
            this.imeTima = imeT;
            this.naslovAplikacije = naslovA;
            this.opisAplikacije = opisA;
            this.idStatusa = status;
            this.bodovi = bodov;
        }
    }
}
