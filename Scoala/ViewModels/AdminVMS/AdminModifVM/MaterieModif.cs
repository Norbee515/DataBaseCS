using Scoala.Models.BusinessLogic;
using Scoala.Models.EntityLayer;
using Scoala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Scoala.ViewModels.AdminVMS.AdminModifVM
{
    class MaterieModif : BasePropertyChanged
    {
        MaterieBLL matBLL = new MaterieBLL();

        public MaterieModif()
        {
            MateriList = matBLL.GetAllMaterii();
        }


        public ObservableCollection<Materie> MateriList
        {
            get
            {
                return matBLL.MateriList;
            }
            set
            {
                matBLL.MateriList = value;
            }
        }
        private Materie selectedMat;
        public Materie SelectedMat
        {
            get { return selectedMat; }
            set
            {
                selectedMat = value;
                //SelectedClasa = Functions.Help_Funct.SelectedClasa;
                NotifyPropertyChanged("SelectedMat");
            }
        }

       
        private ICommand modifCommand;
        public ICommand ModifCommand
        {
            get
            {
                if (modifCommand == null)
                {
                    modifCommand = new RelayCommand<Materie>(matBLL.ModifyMat);
                }

                return modifCommand;
            }
        }
    }
}
