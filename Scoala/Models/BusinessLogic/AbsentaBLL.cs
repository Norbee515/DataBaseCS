using Scoala.Models.DataLayer;
using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.BusinessLogic
{
    class AbsentaBLL
    {

        public ObservableCollection<Absenta> StudentAbsList { get; set; }

        public ObservableCollection<Absenta> GetAllMissFromStudent(int? smt)
        {
            return absDAL.GetAllMissFromStudent(smt);
        }

        AbsentaDAL absDAL = new AbsentaDAL();

        public ObservableCollection<Absenta> StudentAbsProfList { get; set; }

        public void AddAbs(Absenta a)
        {
            AbsentaDAL absDAL = new AbsentaDAL();
            a.Data = a.DataD.ToString();
            a.E_motiv = "Nu e motivata";
            absDAL.AddAbs(a);
            StudentAbsProfList.Add(a);
        }
        public ObservableCollection<Absenta> GetAbsProf()
        {
            if (Functions.Help_Funct.CurrentUser != null)
                if (Functions.Help_Funct.SelectedElev != null)
                    return absDAL.GetAbsForProf();
            return null;
        }

        
        public void DeleteAbs(Absenta a)
        {
            AbsentaDAL absDAL = new AbsentaDAL();
            absDAL.DeleteAbs(a);
            StudentAbsProfList.Remove(a);

        }
        public void ModifyAbs(Absenta a)
        {

            AbsentaDAL absDAL = new AbsentaDAL();
            absDAL.ModifAbs(a);
           
        }
    }
}
