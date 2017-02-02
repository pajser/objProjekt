using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace handling_projects.Helpers
{
    public class DBhelper
    {
        private string connectionString = "Data Source=DESKTOP-U79K1KR;Initial Catalog=OObjektProjekt;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

        private SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;


        public DBhelper(string _query)
        {
            connection = new SqlConnection(connectionString);
            command = connection.CreateCommand();
            command.CommandText = _query;
            connection.Open();

        }

        public void disposeHelper(){
            
            connection.Dispose();
            command.Dispose();
            

        }

    }
}