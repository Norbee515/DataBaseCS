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
using System.Windows.Shapes;

namespace Scoala.Views
{
    /// <summary>
    /// Interaction logic for AdminW.xaml
    /// </summary>
    public partial class AdminW : Window
    {
        public AdminW()
        {
            InitializeComponent();
            Main.Content = new AdminPages.AdminStart(this);
        }

    }
}
