using Scoala.Models.BusinessLogic;
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
    class ProfesorDAL
    {
        public ObservableCollection<Profesor> GetAllProfs()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Profesors", my_con);
                ObservableCollection<Profesor> result = new ObservableCollection<Profesor>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Profesor my_prof = new Profesor();
                    my_prof.IdProf= reader[0].ToString();
                    my_prof.Nume_pren = reader[1].ToString();
                    my_prof.IDUser = (int)reader[2];
                    result.Add(my_prof);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }
        public ObservableCollection<Profesor> GetAllProfsModif()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Profs_Modif", my_con);
                ObservableCollection<Profesor> result = new ObservableCollection<Profesor>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Profesor my_prof = new Profesor();
                    my_prof.IdProf = reader[0].ToString();
                    my_prof.Nume_pren = reader[1].ToString();
                    my_prof.Telefon = reader[2].ToString();
                    my_prof.Adresa = reader[3].ToString();
                    my_prof.UserN = reader[4].ToString();
                    my_prof.Passw = reader[5].ToString();
                    my_prof.IDUser = (int)reader[6];
                    my_prof.IdMat= (int)reader[7];
                    result.Add(my_prof);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }
        public void AddProf(Profesor e)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ADD_User_Prof", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramCNP = new SqlParameter("@cnp", e.IdProf);
                SqlParameter paramNume = new SqlParameter("@nume", e.Nume_pren);
                SqlParameter paramTel = new SqlParameter("@telef", e.Telefon);
                SqlParameter paramAdre = new SqlParameter("@adres", e.Adresa);
                SqlParameter paramUser = new SqlParameter("@user", e.UserN);
                SqlParameter paramPass = new SqlParameter("@pass", e.Passw);

                cmd.Parameters.Add(paramCNP);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramTel);
                cmd.Parameters.Add(paramAdre);
                cmd.Parameters.Add(paramUser);
                cmd.Parameters.Add(paramPass);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            MessageBox.Show("Profesor adaugat cu succes");
        }

        public void DeleteProf(Profesor prof)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Delete_Prof", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", prof.IdProf);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Profesor sters cu succes");
        }

        public void ModifProf(Profesor el)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Modif_Prof", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@cnp", el.IdProf);
                SqlParameter par2 = new SqlParameter("@nume", el.Nume_pren);
                SqlParameter par3 = new SqlParameter("@tel ", el.Telefon);
                SqlParameter par4 = new SqlParameter("@adre", el.Adresa);
                SqlParameter par5 = new SqlParameter("@user", el.UserN);
                SqlParameter par6 = new SqlParameter("@pass", el.Passw);
                SqlParameter par7 = new SqlParameter("@id_m", Functions.Help_Funct.SelectedMat.IdMaterie);
                SqlParameter par8 = new SqlParameter("@id_u", el.IDUser);

                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.Parameters.Add(par3);
                cmd.Parameters.Add(par4);
                cmd.Parameters.Add(par5);
                cmd.Parameters.Add(par6);
                cmd.Parameters.Add(par7);
                cmd.Parameters.Add(par8);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Profesor modificat cu succes");
        }
    }
}
