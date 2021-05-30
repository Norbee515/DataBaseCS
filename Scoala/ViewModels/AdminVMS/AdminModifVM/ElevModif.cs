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
    class ElevModif : BasePropertyChanged
    {
        ElevBLL elevBLL = new ElevBLL();
        ClasaBLL clasaBLL = new ClasaBLL();
        
        public ElevModif()
        {
            ElevList = elevBLL.GetAllElevsModif();
            ClasaList = clasaBLL.GetAllClasses();
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
                //SelectedClasa = Functions.Help_Funct.SelectedClasa;
                NotifyPropertyChanged("SelectedElev");
            }
        }

        public ObservableCollection<Clasa> ClasaList
        {
            get
            {
                return clasaBLL.ClasaList;
            }
            set
            {
                clasaBLL.ClasaList = value;
            }
        }
        private Clasa selectedClasa;
        public Clasa SelectedClasa
        {
            get { return selectedClasa; }
            set
            {
                selectedClasa = value;
                Functions.Help_Funct.SelectedClasa = selectedClasa;
                NotifyPropertyChanged("SelectedClasa");
            }
        }
        private ICommand modifCommand;
        public ICommand ModifCommand
        {
            get
            {
                if (modifCommand == null)
                {
                    modifCommand = new RelayCommand<Elev>(elevBLL.ModifyElev);
                }

                return modifCommand;
            }
        }
    }
}
