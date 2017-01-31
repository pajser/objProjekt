using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public  class test_za_test
    {
        
        public static  int zbroji(int x, int y)
        {
            return x + y+2;
        }

        public static string DodajKorisnika_Testiranje(string user, string pass, string imePrezime, string jmbag)
        {
            string connectionStringTest = "INSERT INTO KorisnickiRacun Values ('" + user + "', '" + pass + "', '" + imePrezime + "', '" + jmbag + "')";
            return connectionStringTest;
        }


    }
}
