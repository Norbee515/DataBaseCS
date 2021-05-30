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
    class An_studiuBLL
    {
        An_studiDAL anDAL = new An_studiDAL();

        public ObservableCollection<An_studi> AniList { get; set; }

        public ObservableCollection<An_studi> GetAllAni()
        {
            return anDAL.GetAllAni();
        }
    }
}
