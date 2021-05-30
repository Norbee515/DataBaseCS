using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scoala.Models.DataLayer
{
    class AbsentaDAL
    {
        public ObservableCollection<Absenta> GetAllMissFromStudent(int ?id)
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_UserToElev_Absenta", my_con);
                ObservableCollection<Absenta> result = new ObservableCollection<Absenta>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramIdUser); 
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absenta my_abs = new Absenta();
                    my_abs.IDAbsenta = (int)(reader[0]);
                    my_abs.IDMaterie = (int)(reader[1]);
                    my_abs.IDElev = reader[2].ToString();
                    my_abs.Data = reader[3].ToString(); 
                    my_abs.E_motivbl = ((bool)reader[4] == true) ? "Motivabila" : "Nemotivabila";
                    my_abs.E_motiv = ((bool)reader[5] == true) ? "Motivata" : "Nemotivata"; 
                    my_abs.Nume= reader[6].ToString();
                    my_abs.Semestru = (reader[7].ToString() == "1") ? "Semestrul 1" : "Semestrul 2"; ;
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

        public ObservableCollection<Absenta> GetAbsForProf()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_AbsFromElevsFromProfs", my_con);
                ObservableCollection<Absenta> result = new ObservableCollection<Absenta>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@id_us", Functions.Help_Funct.CurrentUser.IDUser);
                cmd.Parameters.Add(paramIdUser);
                SqlParameter paramIdUser2 = new SqlParameter("id_el", Functions.Help_Funct.SelectedElev.IDElev);
                cmd.Parameters.Add(paramIdUser2);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absenta my_abs = new Absenta();
                    my_abs.IDAbsenta = (int)(reader[0]);
                    my_abs.E_motiv = ((bool)reader[1]==true)? "E motivata": "Nu e motivata";
                    my_abs.Data = reader[2].ToString();
                    DateTime aux;
                    if (DateTime.TryParse(reader[2].ToString(), out aux))
                    {
                        my_abs.DataD = aux;
                    }
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

        public void AddAbs(Absenta a)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Add_AbsentaProf", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@id_mat", Functions.Help_Funct.CurrentProfMat);
                SqlParameter param2 = new SqlParameter("@id_elev", a.IDElev);
                SqlParameter param3 = new SqlParameter("@data", a.DataD);
                Boolean mot = (a.E_motivbl == "E motivabila") ? true : false;
                SqlParameter param4 = new SqlParameter("@e_mot", mot);
                int sem = (a.Semestru == "Semestrul 1") ? 1 : 2;
                SqlParameter param5 = new SqlParameter("@sem", sem);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Absenta adaugata cu succes");
        }

        public void DeleteAbs(Absenta a)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DELETE_Absenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@id", a.IDAbsenta);
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Absenta stearsa cu succes");
        }

        public void ModifAbs(Absenta a)
        {
            using (SqlConnection con = DALHelper.Connection)
            {

                SqlCommand cmd = new SqlCommand("ModifAbsProf", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@id", a.IDAbsenta);
                SqlParameter par2 = new SqlParameter("@data", a.DataD);

                Boolean mot = (a.E_motiv == "E motivata") ? true : false;
                SqlParameter par3 = new SqlParameter("@e_motiv ", mot);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Absenta modificata cu succes");
        }
    }
}
