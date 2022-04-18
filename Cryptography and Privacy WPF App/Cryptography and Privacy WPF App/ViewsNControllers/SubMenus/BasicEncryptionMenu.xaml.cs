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
    /// Interaction logic for BasicEncryptionMenu.xaml
    /// </summary>
    public partial class BasicEncryptionMenu : Window
    {
        public BasicEncryptionMenu()
        {
            InitializeComponent();
        }

        private void affineButton_Click(object sender, RoutedEventArgs e)
        {
            new AffineCipherWindow().Show();
        }

        private void VigenereCipherButton_Click(object sender, RoutedEventArgs e)
        {
            new VigenerWindow().Show();
        }

        private void railFenceButton_Click(object sender, RoutedEventArgs e)
        {
            new RailFenceWindow().Show();
        }

        private void caesarCipherButton_Click(object sender, RoutedEventArgs e)
        {
            new CaesarCipherWindow().Show();
        }

        private void columnarTranspositionButton_Click(object sender, RoutedEventArgs e)
        {
            new ColumnarTranspositionWindow().Show();
        }

        private void atbashButton_Click(object sender, RoutedEventArgs e)
        {
            new AtbashWindow().Show();
        }
    }
}
