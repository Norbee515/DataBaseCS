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
    class ElevDAL
    {
        public ObservableCollection<Elev> GetAllElevs()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Elevs", my_con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev my_elev = new Elev();
                    my_elev.IDElev = reader[0].ToString();
                    my_elev.Nume_pren = reader[1].ToString();
                    my_elev.IDUser= (int)reader[2];
                    result.Add(my_elev);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }
        public ObservableCollection<Elev> GetAllElevsAnSpec()
        {
            SqlConnection my_con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("Select_Elevs_An_Spec", my_con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAn = new SqlParameter("@id_an", Functions.Help_Funct.SelectedAn.IdAn);
                SqlParameter paramIdSpec = new SqlParameter("@id_spec", Functions.Help_Funct.SelectedSpec.IdSpec);
                cmd.Parameters.Add(paramIdAn);
                cmd.Parameters.Add(paramIdSpec);
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev my_elev = new Elev();
                    my_elev.IDElev = reader[0].ToString();
                    my_elev.Nume_pren = reader[1].ToString();
                    result.Add(my_elev);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }
        public ObservableCollection<Elev> GetAllElevsModif()
        {
            SqlConnection my_con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("Select_Elevs_Modif", my_con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                my_con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev my_elev = new Elev();
                    my_elev.IDElev = reader[0].ToString();
                    my_elev.Nume_pren = reader[1].ToString();
                    my_elev.Telefon = reader[2].ToString();
                    my_elev.Adresa = reader[3].ToString();
                    my_elev.UserN = reader[4].ToString();
                    my_elev.Passw = reader[5].ToString();
                    my_elev.IDUser = (int)reader[6];
                    my_elev.IdCatalog = (reader[7] ==DBNull.Value)? 0 : (int)reader[7];
                    ClasaBLL clasaBLL = new ClasaBLL();
                    my_elev.Clasa = clasaBLL.GetClassesStudent(my_elev.IDElev);
                    result.Add(my_elev);
                }
                reader.Close();
                return result;
            }
            finally
            {
                my_con.Close();
            }
        }
        public void AddEl(Elev e)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ADD_User_Elev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramCNP = new SqlParameter("@cnp", e.IDElev);
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
            MessageBox.Show("Elev adaugat cu succes");
        }
        public void DeleteElev(Elev mat)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Delete_Elev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", mat.IDElev);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Elev sters cu succes");
        }
        public void ModifElev(Elev el)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Modif_elev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@cnp" ,el.IDElev);
                SqlParameter par2 = new SqlParameter("@nume", el.Nume_pren);
                SqlParameter par3 = new SqlParameter("@tel ", el.Telefon);
                SqlParameter par4 = new SqlParameter("@adre", el.Adresa);
                SqlParameter par5 = new SqlParameter("@user", el.UserN);
                SqlParameter par6 = new SqlParameter("@pass", el.Passw);
                SqlParameter par7;
                
                if (Functions.Help_Funct.SelectedClasa.IdClasa == 0)
                {  par7 = new SqlParameter("@id_clasa", DBNull.Value); }
                else
                     par7 = new SqlParameter("@id_clasa", Functions.Help_Funct.SelectedClasa.IdClasa);
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
            MessageBox.Show("Elev modificat cu succes");
        }
        public void Cuplaj(Elev el)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("Cuplaj_Elev", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter par1 = new SqlParameter("@id_el", el.IDElev);
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
