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

namespace Scoala.Views.ProfPages
{
    /// <summary>
    /// Interaction logic for Prof_norm_page.xaml
    /// </summary>
    public partial class Prof_norm_page : Page
    {

        private Prof_win my_window { get; set; }
        public Prof_norm_page(Prof_win window)
        {
            my_window = window;
            InitializeComponent();
        }
        private void Absenta(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new ProfNormP.AbsP();
        }

        private void Nota(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new ProfNormP.NotaP();
        }

        private void Medie(object sender, RoutedEventArgs e)
        {

        }
    }
}
