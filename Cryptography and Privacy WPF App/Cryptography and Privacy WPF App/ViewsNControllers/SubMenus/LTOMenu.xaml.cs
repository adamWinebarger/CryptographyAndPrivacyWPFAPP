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

namespace Cryptography_and_Privacy_WPF_App
{
    /// <summary>
    /// Interaction logic for LTOMenu.xaml
    /// </summary>
    public partial class LTOMenu : Window
    {
        public LTOMenu()
        {
            InitializeComponent();
        }

        private void asButton_Click(object sender, RoutedEventArgs e)
        {
            ASMenu a = new ASMenu();
            a.Show();
            //Hide();
            
            
        }

        private void enButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ctButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
