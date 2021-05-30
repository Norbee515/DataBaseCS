using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Scoala.Models.DataLayer
{
    class An_studiDAL
    {
        public ObservableCollection<An_studi> GetAllAni()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_AN_studii", my_con);
                ObservableCollection<An_studi> result = new ObservableCollection<An_studi>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    An_studi my_an = new An_studi();
                    my_an.IdAn = (int)reader[0];
                    my_an.Nume = reader[1].ToString();
                    result.Add(my_an);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }
    }
}
