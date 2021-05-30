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

namespace Scoala.ViewModels.ProfVMS
{
    class ProfNotaP : BasePropertyChanged
    {
        ElevBLL elevBLL = new ElevBLL();
        NotaBLL notaBLL = new NotaBLL();
        public static ObservableCollection<string> Semesters { get; set; } = new ObservableCollection<string> { "Semestrul 1", "Semestrul 2" };
        public ProfNotaP()
        {
            NotaAdd = new Nota();
            SelectedTime = DateTime.Now;
            SelectedTimeAdd = DateTime.Now;
            ElevList = elevBLL.GetAllElevs();
            NotaAdd.DataD = SelectedTimeAdd;
            NotaList = notaBLL.GetNotaProf();
        }

        private string selectedSem;
        public string SelectedSem
        {
            get { return selectedSem; }
            set
            {
                selectedSem = value;
                Functions.Help_Funct.SelectedSem = selectedSem;
                NotifyPropertyChanged("SelectedSem");
            }
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
        public ObservableCollection<Nota> NotaList
        {
            get
            {
                return notaBLL.StudentNotaProfList;
            }
            set
            {
                notaBLL.StudentNotaProfList=value;
                NotifyPropertyChanged("NotaList");
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
                    NotaAdd.IDElev = selectedElev.IDElev;
                    NotaList = notaBLL.GetNotaProf();
                }
                NotifyPropertyChanged("SelectedElev");
            }
        }
        private Nota selectedNota;
        public Nota SelectedNota
        {
            get { return selectedNota; }
            set
            {
                selectedNota = value;
                NotifyPropertyChanged("SelectedNota");
            }
        }
        private Nota notaAdd;
        public Nota NotaAdd
        {
            get { return notaAdd; }
            set
            {
                notaAdd = value;
                NotifyPropertyChanged("NotaAdd");
            }
        }


        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Nota>(notaBLL.AddNota);
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
                    deleteCommand = new RelayCommand<Nota>(notaBLL.DeleteNota);
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
                    modifCommand = new RelayCommand<Nota>(notaBLL.ModifyNota);
                }

                return modifCommand;
            }
        }

    }
}
