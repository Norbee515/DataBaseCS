using Scoala.Models.DataLayer;
using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scoala.Models.BusinessLogic
{
    class ProfesorBLL
    {
        ProfesorDAL profDAL = new ProfesorDAL();
        public ObservableCollection<Profesor> ProfesorList { get; set; }

        public ObservableCollection<Profesor> GetAllProfs()
        {
            return profDAL.GetAllProfs();
        }
        public ObservableCollection<Profesor> GetAllProfsModif()
        {
            return profDAL.GetAllProfsModif();
        }
        public void AddProf(Profesor e)
        {
 
            ProfesorDAL profDAL = new ProfesorDAL();
            profDAL.AddProf(e);
            //ProfesorList.Add(e);

        }

        public void DeleteProf(Profesor prof)
        {
            ProfesorDAL profDAL = new ProfesorDAL();
            profDAL.DeleteProf(prof);
            ProfesorList.Remove(prof);

        }
        public void ModifyElev(Profesor prof)
        {

            ProfesorDAL profDAL = new ProfesorDAL();
            profDAL.ModifProf(prof);
        }
    }
}
