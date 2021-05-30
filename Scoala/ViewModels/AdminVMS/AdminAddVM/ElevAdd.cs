using Scoala.Models.EntityLayer;
using Scoala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Scoala.Models.BusinessLogic;

namespace Scoala.ViewModels.AdminVMS.AdminAddVM
{
    class ElevAdd : BasePropertyChanged
    {
        ElevBLL elevBLL = new ElevBLL();

        private ICommand addElevComm;
        public ICommand AddElevComm
        {
            get
            {
                if (addElevComm == null)
                {
                    addElevComm = new RelayCommand<Elev>(elevBLL.AddEl);

                }

                return addElevComm;
            }
        }
    }
}
