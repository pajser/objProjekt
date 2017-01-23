﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ClanTimaTablica
    {
        public List<ClanTimaPredlozakcs> povezani;
        private static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.bazaOBJConnectionString"].ConnectionString;

        public static bool dodaj(int idKR, int idT, bool glavni)
        {
            if (glavni) {}
            ClanTimaPredlozakcs novi = new ClanTimaPredlozakcs(idKR, idT, glavni);            
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO ClanTIma values (" + novi.idKorisnickiRacun + ", " + novi.idTima + ", '" + novi.vodja + "')";
            try
            {
                conn.Open();
                int test = command.ExecuteNonQuery();
                if (test > 0)
                {
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;
            }
            return false;
            //tu ide dodavanje i u bazu   
        }

    }
}
