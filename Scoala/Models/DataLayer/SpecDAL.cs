using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;

namespace Scoala.Models.DataLayer
{
    class SpecDAL
    {
        public ObservableCollection<Spec> GetAllSpec()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Spec", my_con);
                ObservableCollection<Spec> result = new ObservableCollection<Spec>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spec my_spec = new Spec();
                    my_spec.IdSpec= (int)reader[0];
                    my_spec.Nume = reader[1].ToString();
                    result.Add(my_spec);
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
