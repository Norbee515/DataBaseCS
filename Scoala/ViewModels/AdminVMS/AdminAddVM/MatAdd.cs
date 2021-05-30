using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Scoala.Models.BusinessLogic;
using Scoala.ViewModels.Commands;
using Scoala.Models.EntityLayer;
namespace Scoala.ViewModels.AdminVMS.AdminAddVM
{
    class MatAdd : BasePropertyChanged
    {
        public static ObservableCollection<string> TezaChoices { get; set; } = new ObservableCollection<string> { "Are Teza", "Nu Are Teza" };

        private string selectedTezaChoice;
        public string SelectedTezaChoice
        {
            get { return selectedTezaChoice; }
            set
            {
                selectedTezaChoice = value;
                Functions.Help_Funct.SelectedTezaChoice = selectedTezaChoice;
                NotifyPropertyChanged("SelectedTezaChoice");
            }
        }


        MaterieBLL matBLL = new MaterieBLL();



        private ICommand addMatComm;
        public ICommand AddMatComm
        {
            get
            {
                if (addMatComm == null)
                {
                    addMatComm = new RelayCommand<string>(matBLL.AddMat);

                }

                return addMatComm;
            }
        }
    }
}
