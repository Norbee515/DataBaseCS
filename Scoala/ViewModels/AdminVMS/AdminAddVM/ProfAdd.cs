using Scoala.Models.EntityLayer;
using Scoala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.BusinessLogic;
using System.Windows.Input;

namespace Scoala.ViewModels.AdminVMS.AdminAddVM
{
    class ProfAdd : BasePropertyChanged
    {
        public static ObservableCollection<string> Dirig_Class_Availb { get; set; } = new ObservableCollection<string> { "Nu e diriginte" };

        private string selectedClassesAvailb;
        public string SelectedClassesAvailb
        {
            get { return selectedClassesAvailb; }
            set
            {
                selectedClassesAvailb = value;
                NotifyPropertyChanged("SelectedClassesAvailb");
            }
        }


        ProfesorBLL profBLL = new ProfesorBLL();
        private ICommand addProfComm;
        public ICommand AddProfComm
        {
            get
            {
                if (addProfComm == null)
                {
                    addProfComm = new RelayCommand<Profesor>(profBLL.AddProf);

                }

                return addProfComm;
            }
        }
    }
}
