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
    class MaterieDAL
    {
        public ObservableCollection<Materie> GetAllSubjFromStudent(int? id)
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Materii_User", my_con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUser = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramIdUser);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Materie first_mat = new Materie() { IdMaterie = 0, Nume = "Toate", Are_teza = false };
                result.Add(first_mat);
                while (reader.Read())
                {
                    Materie my_mat = new Materie();
                    my_mat.IdMaterie = (int)(reader[0]);
                    my_mat.Nume = reader[1].ToString();
                    my_mat.Are_teza = (bool)reader[2];
                    result.Add(my_mat);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }

        public ObservableCollection<Materie> GetAllMaterii()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Materii", my_con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie my_mat = new Materie();
                    my_mat.IdMaterie = (int)reader[0];
                    my_mat.Nume = reader[1].ToString();
                    my_mat.Are_tezaS = ((bool)reader[2]==true) ? "Are Teza" : "Nu are Teza";
                    result.Add(my_mat);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }

        public ObservableCollection<Materie> GetAllMateriiAnSpec()
        {
            SqlConnection my_con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("Select_Materii_An_Spec", my_con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAn = new SqlParameter("@id_an", Functions.Help_Funct.SelectedAn.IdAn);
                SqlParameter paramIdSpec = new SqlParameter("@id_spec", Functions.Help_Funct.SelectedSpec.IdSpec);
                cmd.Parameters.Add(paramIdAn);
                cmd.Parameters.Add(paramIdSpec);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie my_mat = new Materie();
                    my_mat.IdMaterie = (int)(reader[0]);
                    my_mat.Nume = reader[1].ToString();
                    my_mat.Are_teza = (bool)reader[2];
                    result.Add(my_mat);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }

        public void AddMat(string e)
        {
            var ceva = (Functions.Help_Funct.SelectedTezaChoice == "Are Teza") ? 1 : 0;
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ADD_Materie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", e);
                SqlParameter paramTeza = new SqlParameter("@tez", ceva);


                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramTeza);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Materie adaugata cu succes");
        }

        public int GetIdMatProfUser()
        {
            SqlConnection my_con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("Select_Mat_Prof", my_con);
                int result=0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", Functions.Help_Funct.CurrentUser.IDUser);
                cmd.Parameters.Add(paramId);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    result= (int)(reader[0]);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }

        public void DeleteMaterie(Materie mat)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Delete_Materie", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", mat.IdMaterie);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Materie stearsa cu succes");
        }
        public void ModifMat(Materie mat)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Modif_Absenta", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@id", mat.IdMaterie);
                SqlParameter par2 = new SqlParameter("@nume", mat.Nume);
                var ceva = (mat.Are_tezaS == "Are Teza") ? 1 : 0;
                SqlParameter par3 = new SqlParameter("@teza ", ceva);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Materie modificata cu succes");
        }
        public void Cuplaj(Materie mat)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Cuplaj_Mat", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@id_mat", mat.IdMaterie);
                SqlParameter par2 = new SqlParameter("@id_a", Functions.Help_Funct.SelectedAn.IdAn);
                SqlParameter par3 = new SqlParameter("@id_spec", Functions.Help_Funct.SelectedSpec.IdSpec);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Cuplajul a fost realizat cu succes");
        }
    }
   
}
