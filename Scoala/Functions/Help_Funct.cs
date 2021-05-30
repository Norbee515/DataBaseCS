using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Scoala.Functions
{
    class Help_Funct
    {
        public static User CurrentUser { get; set; }

        public static List<string> UserChoices { get; set; }

        public static ObservableCollection<Materie> UserDisciplines { get; set; }

        public static string SelectedChoice { get; set; }

        public static ObservableCollection<Absenta> AbsList { get; set; }

        public static string SelectedSem { get; set; }

        public static string SelectedM { get; set; }

        public static string SelectedMBL { get; set; }

        public static string SelectedTezaChoice { get; set; }

        public static Clasa SelectedClasa { get; set; }

        public static Materie SelectedMat { get; set; }

        public static An_studi SelectedAn { get; set; } = null;

        public static Spec SelectedSpec { get; set; }

        public static string SelectedSemAdd{get;set;}

        public static Elev SelectedElev { get; set; }

        public static int CurrentProfMat { get; set; }
    }
}
