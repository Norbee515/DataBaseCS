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
    class ClasaDAL
    {
        public Clasa GetAllClassFromStudent(string id)
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Elev_Class", my_con);
                Clasa result = new Clasa();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramIdUser);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Clasa my_clas = new Clasa();
                    my_clas.IdClasa = (int)(reader[0]);
                    my_clas.Grupa = reader[1].ToString();
                    my_clas.Profil = reader[2].ToString();
                    result = my_clas;
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }

        public ObservableCollection<Clasa> GetAllClasses()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_All_Classes", my_con);
                ObservableCollection<Clasa> result = new ObservableCollection<Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa my_clas = new Clasa();
                    my_clas.IdClasa = (int)(reader[0]);
                    my_clas.Grupa = reader[1].ToString();
                    my_clas.Profil = reader[2].ToString();
                    result.Add(my_clas);
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
