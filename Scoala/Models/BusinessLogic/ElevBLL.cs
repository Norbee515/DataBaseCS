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
    class ElevBLL
    {
        
        public ObservableCollection<Elev> ElevList { get; set; }

        ElevDAL elevDAL = new ElevDAL();

        public ObservableCollection<Elev> GetAllElevs()
        {
            return elevDAL.GetAllElevs();
        }

        public ObservableCollection<Elev> GetAllElevsModif()
        {
            return elevDAL.GetAllElevsModif();
        }
        public void AddEl(Elev el) 
        {
            ElevDAL eleDAL = new ElevDAL();
            eleDAL.AddEl(el);
            //ElevList.Add(el);
        }

        public void DeleteElev(Elev el)
        {
            ElevDAL eleDAL = new ElevDAL();
            eleDAL.DeleteElev(el);
            ElevList.Remove(el);

        }
        public void ModifyElev(Elev el)
        {
            
            ElevDAL elevDAL = new ElevDAL();
            elevDAL.ModifElev(el);
        }

        public ObservableCollection<Elev> ElevAnSpecList { get; set; }
        public ObservableCollection<Elev> GetAllElevAnSpec()
        {
            return elevDAL.GetAllElevsAnSpec();
        }
        public void Cuplaj(Elev elev)
        {
            int k = 0;
            foreach (var e in ElevAnSpecList)
                if (e.IDElev == elev.IDElev)
                    k++;
            if (k == 0)
            {
                elevDAL.Cuplaj(elev);
                ElevAnSpecList.Add(elev);
            }
            else MessageBox.Show("Elevul e deja");
        }
    }
}
