using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.DataLayer;
using Scoala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace Scoala.Models.BusinessLogic
{
    class SpecBLL
    {
        SpecDAL specDAL = new SpecDAL();

        public ObservableCollection<Spec> SpecList { get; set; }

        public ObservableCollection<Spec> GetAllSpec()
        {
            return specDAL.GetAllSpec();
        }
    }
}
