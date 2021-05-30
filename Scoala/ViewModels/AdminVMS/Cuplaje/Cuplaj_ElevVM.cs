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
    class Cuplaj_ElevVM : BasePropertyChanged
    {
        
        ElevBLL elevBLL = new ElevBLL();
        SpecBLL specBLL = new SpecBLL();
        An_studiuBLL anBLL = new An_studiuBLL();

        public Cuplaj_ElevVM()
        {
            ElevList = elevBLL.GetAllElevs();
            AniList = anBLL.GetAllAni();
            SpecList = specBLL.GetAllSpec();
        }
        public ObservableCollection<Elev> ElevList
        {
            get
            {
                return elevBLL.ElevList;
            }
            set
            {
                elevBLL.ElevList = value;
            }
        }
        private Elev selectedElev;
        public Elev SelectedElev
        {
            get { return selectedElev; }
            set
            {
                selectedElev = value;
                NotifyPropertyChanged("SelectedElev");
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
                if (selectedSpec != null && selectedSpec != null)
                    ElevAnSpecList = elevBLL.GetAllElevAnSpec();
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
                    ElevAnSpecList = elevBLL.GetAllElevAnSpec();
                NotifyPropertyChanged("SelectedSpec");
            }
        }

        public ObservableCollection<Elev> ElevAnSpecList
        {
            get
            {
                return elevBLL.ElevAnSpecList;
            }
            set
            {
                elevBLL.ElevAnSpecList = value;
                NotifyPropertyChanged("ElevAnSpecList");
            }
        }

        private ICommand cuplCommand;
        public ICommand CuplCommand
        {
            get
            {
                if (cuplCommand == null)
                {
                    cuplCommand = new RelayCommand<Elev>(elevBLL.Cuplaj);

                }

                return cuplCommand;
            }
        }
    }
}
