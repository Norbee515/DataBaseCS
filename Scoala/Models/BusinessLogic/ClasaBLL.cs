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
    class ClasaBLL
    {
        ClasaDAL clsDAL = new ClasaDAL();
        public Clasa GetClassesStudent(string smt)
        {
            return clsDAL.GetAllClassFromStudent(smt);
        }

        public ObservableCollection<Clasa> ClasaList { get; set; }

        public ObservableCollection<Clasa> GetAllClasses()
        {
            return clsDAL.GetAllClasses();
        }
    }
}
