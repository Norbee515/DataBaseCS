using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scoala.Views.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminModif.xaml
    /// </summary>
    public partial class AdminModif : Page
    {
        private AdminW my_window { get; set; }
        public AdminModif(AdminW window)
        {
            my_window = window;
            InitializeComponent();
        }

        private void Modif_Elev(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new ModifPages.ElevModif();
        }

        private void Modif_Prof(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new ModifPages.ProfModif();
        }

        private void Modif_Mat(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new ModifPages.MaterieModif();
        }
        
        
        
    }
}
