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
    /// Interaction logic for ASMenu.xaml
    /// </summary>
    public partial class ASMenu : Window
    {
        public ASMenu()
        {
            InitializeComponent();
        }

        private void as1Button_Click(object sender, RoutedEventArgs e)
        {
            new AS1Window().Show();
        }

        private void as2Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void as3Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void as4Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void as5Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
