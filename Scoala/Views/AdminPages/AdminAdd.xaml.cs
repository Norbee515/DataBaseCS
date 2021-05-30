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
    /// Interaction logic for AdminAdd.xaml
    /// </summary>
    public partial class AdminAdd : Page
    {
        private AdminW my_window { get; set; }
        public AdminAdd(AdminW window)
        {
            my_window = window;
            InitializeComponent();
        }

        private void Add_Elev(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new AddPages.ElevAddP();
        }

        private void Add_Prof(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new AddPages.ProfAddP();
        }

        private void Add_Mat(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new AddPages.MatAddP();
        }


    }
}
