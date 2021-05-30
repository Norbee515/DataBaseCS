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
    /// Interaction logic for AdminStart.xaml
    /// </summary>
    public partial class AdminStart : Page
    {
        private AdminW my_window { get; set; }
        public AdminStart(AdminW window)
        {
            my_window = window;
            InitializeComponent();
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new AdminPages.AdminAdd(my_window);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new AdminPages.AdminDelete();
        }

        private void Modif(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new AdminPages.AdminModif(my_window);
        }

        private void Cuplaj_Elev_Clasa(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new Cuplaj_Elev_Clasa();
        }

        private void Cuplaj_Mat_Clasa(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new Cuplaj_Mat_Clasa();
        }
    }
}
