using System;
using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scoala.Models.DataLayer
{
    class NotaDAL
    {
        public ObservableCollection<Nota> GetAllMarkFromStudent(int? id)
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_UserToElev_Nota", my_con);
                ObservableCollection<Nota> result = new ObservableCollection<Nota>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramIdUser);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota my_abs = new Nota();
                    my_abs.IDNota = (int)(reader[0]);
                    my_abs.IDMaterie = (int)(reader[1]);
                    my_abs.IDElev = reader[2].ToString();
                    my_abs.Data = reader[3].ToString();
                    my_abs.E_teza = ((bool)reader[4] == true) ? "Teza" : "Nu e teza";
                    my_abs.Nota_str = reader[5].ToString();
                    my_abs.Nume = reader[6].ToString();
                    my_abs.Semestru = (reader[7].ToString() == "1") ? "Semestrul 1" : "Semestrul 2"; 
                    result.Add(my_abs);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }

        public ObservableCollection<Nota> GetObjMarkFromStudent(int? id_use,int? id_mat)
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_UserToElev_Nota_Mat", my_con);
                ObservableCollection<Nota> result = new ObservableCollection<Nota>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@id_user", id_use);
                cmd.Parameters.Add(paramIdUser);
                SqlParameter paramIdUser2 = new SqlParameter("@id_mat", id_mat);
                cmd.Parameters.Add(paramIdUser2);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota my_abs = new Nota();
                    my_abs.IDNota = (int)(reader[0]);
                    my_abs.IDMaterie = (int)(reader[1]);
                    my_abs.IDElev = reader[2].ToString();
                    my_abs.Data = reader[3].ToString();
                    my_abs.E_teza = ((bool)reader[4] == true) ? "Teza" : "Nu e teza";
                    my_abs.Nota_str = reader[5].ToString();
                    my_abs.Nume = reader[6].ToString();
                    my_abs.Semestru = (reader[7].ToString() == "1") ? "Semestrul 1" : "Semestrul 2";
                    result.Add(my_abs);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }
        public ObservableCollection<Nota> GetNotaForProf()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_MatsFromElevsFromProfs", my_con);
                ObservableCollection<Nota> result = new ObservableCollection<Nota>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@id_us",Functions.Help_Funct.CurrentUser.IDUser );
                cmd.Parameters.Add(paramIdUser);
                SqlParameter paramIdUser2 = new SqlParameter("id_el",Functions.Help_Funct.SelectedElev.IDElev );
                cmd.Parameters.Add(paramIdUser2);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota my_abs = new Nota();
                    my_abs.IDNota = (int)(reader[0]);
                    my_abs.Nota_str = reader[1].ToString();
                    my_abs.Data = reader[2].ToString();
                    DateTime aux;
                    if (DateTime.TryParse(reader[2].ToString(), out aux))
                    {
                        my_abs.DataD = aux;
                    }
                    my_abs.E_teza = ((bool)reader[3] == true) ? "Teza" : "Nu e teza";
                    my_abs.Semestru = (reader[4].ToString() == "1") ? "Semestrul 1" : "Semestrul 2";
                    result.Add(my_abs);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }

        public void AddNota(Nota n)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ADD_Nota", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@id_mat", Functions.Help_Funct.CurrentProfMat);
                SqlParameter param2 = new SqlParameter("@id_elev", n.IDElev);
                SqlParameter param3 = new SqlParameter("@data", n.DataD);
                Boolean teza= (n.E_teza == "Are Teza") ? true : false; 
                SqlParameter param4 = new SqlParameter("@e_teza", teza);
                SqlParameter param5 = new SqlParameter("@nota", Convert.ToInt32(n.Nota_str));
                int sem= (n.Semestru == "Semestrul 1") ? 1 : 2; 
                SqlParameter param6 = new SqlParameter("@sem", sem);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Nota adaugata cu succes");
        }

        public void DeleteNota(Nota n)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Delete_Nota", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param= new SqlParameter("@id", n.IDNota);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Nota stearsa cu succes");
        }
        public void ModifNota(Nota n)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                
                
                int sem = (n.Semestru == "Semestrul 1") ? 1 : 2;

                SqlCommand cmd = new SqlCommand("Modif_Nota", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@id",n.IDNota );
                SqlParameter par2 = new SqlParameter("@data", n.DataD);

                Boolean teza = (n.E_teza == "Are Teza") ? true : false;

                SqlParameter par3 = new SqlParameter("@e_teza ", teza);
                SqlParameter par4 = new SqlParameter("@nota ", Convert.ToInt32(n.Nota_str));
                SqlParameter par5 = new SqlParameter("@sem ", sem);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Nota modificata cu succes");
        }
    }
}
