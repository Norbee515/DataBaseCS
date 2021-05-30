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
    class NotaBLL
    {
        public ObservableCollection<Nota> StudentNotaList { get; set; }

        public ObservableCollection<Nota> StudentNotaProfList { get; set; }
        public ObservableCollection<Nota> GetAllMarkFromStudent(int? smt)
        {
            return absDAL.GetAllMarkFromStudent(smt);
        }

        public ObservableCollection<Nota> GetObjMarkFromStudent(int? smt,int? smt2)
        {
            return absDAL.GetObjMarkFromStudent(smt, smt2);
        }

        public void AddNota(Nota n)
        {
            NotaDAL notaDAL = new NotaDAL();
            n.Data = n.DataD.ToString();
            notaDAL.AddNota(n);
            StudentNotaProfList.Add(n);
            //ElevList.Add(el);
        }

        public ObservableCollection<Nota> GetNotaProf()
        {
            if(Functions.Help_Funct.CurrentUser!=null)
                if(Functions.Help_Funct.SelectedElev!=null)
            return absDAL.GetNotaForProf();
            return null;
        }

        NotaDAL absDAL = new NotaDAL();
        public void DeleteNota(Nota n)
        {
            NotaDAL notaDAL = new NotaDAL();
            notaDAL.DeleteNota (n);
            StudentNotaProfList.Remove(n);

        }
        public void ModifyNota(Nota n)
        {

            NotaDAL notaDAL = new NotaDAL();
            notaDAL.ModifNota(n);
        }
    }
}
