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
    /// Interaction logic for Prof_start.xaml
    /// </summary>
    public partial class Prof_start : Page
    {
        private Prof_win my_window { get; set; }
        public Prof_start(Prof_win window)
        {
            my_window = window;
            InitializeComponent();
        }
        private void Prof_mod(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new Prof_norm_page(my_window);
        }

        private void Dirig_mod(object sender, RoutedEventArgs e)
        {
            my_window.Main.Content = new Prof_dirig_page();
        }
    }
}
