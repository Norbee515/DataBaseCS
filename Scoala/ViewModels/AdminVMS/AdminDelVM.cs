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

namespace Scoala.ViewModels.AdminVMS
{
    class AdminDelVM : BasePropertyChanged
    {
        ElevBLL elevBLL = new ElevBLL();
        ProfesorBLL profBLL = new ProfesorBLL();
        MaterieBLL matBLL = new MaterieBLL();
        public AdminDelVM()
        {
           ElevList = elevBLL.GetAllElevs();
           ProfesorList = profBLL.GetAllProfs();
            MateriList = matBLL.GetAllMaterii();
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
        public ObservableCollection<Profesor> ProfesorList
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
                NotifyPropertyChanged("SelectedProf");
            }
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
        private Materie selectedMaterie;
        public Materie SelectedMaterie
        {
            get { return selectedMaterie; }
            set
            {
                selectedMaterie = value;
                NotifyPropertyChanged("SelectedMaterie");
            }
        }
        private ICommand delElevCommand;
        public ICommand DelElevCommand
        {
            get
            {
                if (delElevCommand == null)
                {
                    delElevCommand = new RelayCommand<Elev>(elevBLL.DeleteElev);
                }

                return delElevCommand;
            }
        }
        private ICommand delProfCommand;
        public ICommand DelProfCommand
        {
            get
            {
                if (delProfCommand == null)
                {
                    delProfCommand = new RelayCommand<Profesor>(profBLL.DeleteProf);
                }

                return delProfCommand;
            }
        }
        private ICommand delMatCommand;
        public ICommand DelMatCommand
        {
            get
            {
                if (delMatCommand == null)
                {
                    delMatCommand = new RelayCommand<Materie>(matBLL.DeleteMat);
                }

                return delMatCommand;
            }
        }

    }
}
