using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MangAtongsPrototype
{
    public class DBConnection
    {
        public SqlConnection con;

        public string GetConnectionString
        {
            get
            {
                return "con";
            }
        }

        public DBConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

    }
}