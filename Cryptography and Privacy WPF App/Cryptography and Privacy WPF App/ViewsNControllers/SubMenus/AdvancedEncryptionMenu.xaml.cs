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
    /// Interaction logic for AdvancedEncryptionMenu.xaml
    /// </summary>
    public partial class AdvancedEncryptionMenu : Window
    {
        public AdvancedEncryptionMenu()
        {
            InitializeComponent();
            enigmaButton.Visibility = Visibility.Hidden;
            rsaButton.Visibility = Visibility.Hidden;
        }

        private void aesButton_Click(object sender, RoutedEventArgs e)
        {
            new AESWindow().Show();
        }

        private void adfgvxButton_Click(object sender, RoutedEventArgs e)
        {
            new ADFGVXWindow().Show();
        }

        private void hillCipherButton_Click(object sender, RoutedEventArgs e)
        {
            new HillCipherWindow().Show();
        }
    }
}
