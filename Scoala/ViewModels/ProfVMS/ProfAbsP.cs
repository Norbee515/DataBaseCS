using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scoala.Models.BusinessLogic;
using Scoala.Models.EntityLayer;
using Scoala.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Scoala.ViewModels.ProfVMS
{
    class ProfAbsP : BasePropertyChanged
    {
        ElevBLL elevBLL = new ElevBLL();
        AbsentaBLL absBLL = new AbsentaBLL();
        public ProfAbsP()
        {
            AbsAdd = new Absenta();
            SelectedTime = DateTime.Now;
            SelectedTimeAdd = DateTime.Now;
            ElevList = elevBLL.GetAllElevs();
            AbsAdd.DataD = SelectedTimeAdd;
            AbsList = absBLL.GetAbsProf();
        }
        private DateTime selectedTime;
        public DateTime SelectedTime
        {
            get { return selectedTime; }
            set
            {
                selectedTime = value;
                //Functions.Help_Funct.SelectedSem = selectedSem;
                NotifyPropertyChanged("SelectedTime");
            }
        }

        private DateTime selectedTimeAdd;
        public DateTime SelectedTimeAdd
        {
            get { return selectedTimeAdd; }
            set
            {
                selectedTimeAdd = value;
                //Functions.Help_Funct.SelectedSem = selectedSem;
                NotifyPropertyChanged("SelectedTimeAdd");
            }
        }
        public static ObservableCollection<string> Semesters { get; set; } = new ObservableCollection<string> { "Semestrul 1", "Semestrul 2" };

        public static ObservableCollection<string> E_Motivbl { get; set; } = new ObservableCollection<string> { "E motivabila", "Nu e motivabila" };

        public static ObservableCollection<string> E_Motiv { get; set; } = new ObservableCollection<string> { "E motivata", "Nu e motivata" };

        private string selectedSemAdd;
        public string SelectedSemAdd
        {
            get { return selectedSemAdd; }
            set
            {
                selectedSemAdd = value;
                Functions.Help_Funct.SelectedSemAdd = selectedSemAdd;
                NotifyPropertyChanged("SelectedSemAdd");
            }
        }

        private string selectedMBL;
        public string SelectedMBL
        {
            get { return selectedMBL; }
            set
            {
                selectedMBL = value;
                Functions.Help_Funct.SelectedMBL = selectedMBL;
                NotifyPropertyChanged("SelectedMBL");
            }
        }
        private string selectedM;
        public string SelectedM
        {
            get { return selectedM; }
            set
            {
                selectedM = value;
                Functions.Help_Funct.SelectedM = selectedM;
                NotifyPropertyChanged("SelectedM");
            }
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
        public ObservableCollection<Absenta> AbsList
        {
            get
            {
                return absBLL.StudentAbsProfList;
            }
            set
            {
                absBLL.StudentAbsProfList = value;
                NotifyPropertyChanged("AbsList");
            }
        }

        private Elev selectedElev;
        public Elev SelectedElev
        {
            get { return selectedElev; }
            set
            {
                selectedElev = value;
                Functions.Help_Funct.SelectedElev = selectedElev;
                if (selectedElev.IDElev != null)
                {
                    AbsAdd.IDElev = selectedElev.IDElev;
                    AbsList = absBLL.GetAbsProf();
                }
                NotifyPropertyChanged("SelectedElev");
            }
        }
        private Absenta selectedAbs;
        public Absenta SelectedAbs
        {
            get { return selectedAbs; }
            set
            {
                selectedAbs = value;
                NotifyPropertyChanged("SelectedAbs");
            }
        }
        private Absenta absAdd;
        public Absenta AbsAdd
        {
            get { return absAdd; }
            set
            {
                absAdd = value;
                NotifyPropertyChanged("AbsAdd");
            }
        }
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Absenta>(absBLL.AddAbs);
                }

                return addCommand;
            }
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Absenta>(absBLL.DeleteAbs);
                }

                return deleteCommand;
            }
        }
        private ICommand modifCommand;
        public ICommand ModifCommand
        {
            get
            {
                if (modifCommand == null)
                {
                    modifCommand = new RelayCommand<Absenta>(absBLL.ModifyAbs);
                }

                return modifCommand;
            }
        }

    }
}
