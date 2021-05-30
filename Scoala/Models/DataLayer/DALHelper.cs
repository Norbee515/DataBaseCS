using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Scoala.Models.DataLayer
{
    static class DALHelper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DESKTOP-1GC968J"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
