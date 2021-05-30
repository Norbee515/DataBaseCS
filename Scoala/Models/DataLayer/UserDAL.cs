using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.DataLayer
{
    class UserDAL
    {
        public ObservableCollection<User> GetAllUsers()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Users", my_con);
                ObservableCollection<User> result = new ObservableCollection<User>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User my_user  = new User();
                    my_user.IDUser= (int)(reader[0]);
                    my_user.Username= reader[1].ToString();
                    my_user.Password = reader[2].ToString();
                    my_user.Rol= reader[3].ToString();
                    result.Add(my_user);
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
