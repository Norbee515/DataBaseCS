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
    class ProfModif : BasePropertyChanged
    {
        ProfesorBLL profBLL = new ProfesorBLL();
        MaterieBLL matBLL = new MaterieBLL();

        public ProfModif()
        {
            //ElevList = elevBLL.GetAllElevsModif();
            //ClasaList = clasaBLL.GetAllClasses();
            ProfList = profBLL.GetAllProfsModif();
            MatList = matBLL.GetAllMaterii();
        }


        public ObservableCollection<Profesor> ProfList
        {
            get
            {
                return profBLL.ProfesorList;
            }
            set
            {
                profBLL.ProfesorList = value;
            }
        }
        private Profesor selectedProf;
        public Profesor SelectedProf
        {
            get { return selectedProf; }
            set
            {
                selectedProf = value;
                //SelectedClasa = Functions.Help_Funct.SelectedClasa;
                NotifyPropertyChanged("SelectedProf");
            }
        }

        public ObservableCollection<Materie> MatList
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
                Functions.Help_Funct.SelectedMat = selectedMat;
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
                   modifCommand = new RelayCommand<Profesor>(profBLL.ModifyElev);
                }

                return modifCommand;
            }
        }
    }
}
