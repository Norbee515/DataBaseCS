using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.BusinessLogic;
using Scoala.Models.EntityLayer;
using Scoala.ViewModels.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Scoala.ViewModels.AdminVMS.Cuplaje
{
    class Cuplaj_MatVM : BasePropertyChanged
    {
        MaterieBLL matBLL = new MaterieBLL();
        SpecBLL specBLL = new SpecBLL();
        An_studiuBLL anBLL = new An_studiuBLL();

        public Cuplaj_MatVM()
        {
            MateriList = matBLL.GetAllMaterii();
            AniList = anBLL.GetAllAni();
            SpecList = specBLL.GetAllSpec();
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
                NotifyPropertyChanged("SelectedMat");
            }
        }
        public ObservableCollection<An_studi> AniList
        {
            get
            {
                return anBLL.AniList;
            }
            set
            {
                anBLL.AniList = value;
            }
        }
        private An_studi selectedAn;
        public An_studi SelectedAn
        {
            get { return selectedAn; }
            set
            {
                selectedAn = value;
                Functions.Help_Funct.SelectedAn = selectedAn;
               if (selectedSpec != null && selectedSpec!=null)
                    MateriAnSpecList = matBLL.GetAllMateriiAnSpec();
                NotifyPropertyChanged("SelectedAn");
            }
        }
        public ObservableCollection<Spec> SpecList
        {
            get
            {
                return specBLL.SpecList;
            }
            set
            {
                specBLL.SpecList = value;
            }
        }
        private Spec selectedSpec;
        public Spec SelectedSpec
        {
            get { return selectedSpec; }
            set
            {
                selectedSpec = value;
                Functions.Help_Funct.SelectedSpec = selectedSpec;
                if (selectedSpec != null && selectedSpec != null)
                    MateriAnSpecList = matBLL.GetAllMateriiAnSpec();
                NotifyPropertyChanged("SelectedSpec");
            }
        }

        public ObservableCollection<Materie> MateriAnSpecList
        {
            get
            {
                return matBLL.MateriAnSpecList;
            }
            set
            {
                matBLL.MateriAnSpecList = value;
                NotifyPropertyChanged("MateriAnSpecList");
            }
        }
        
        private ICommand cuplCommand;
        public ICommand CuplCommand
        {
            get
            {
                if (cuplCommand == null)
                {
                    cuplCommand = new RelayCommand<Materie>(matBLL.Cuplaj);

                }

                return cuplCommand;
            }
        }
    }
}
