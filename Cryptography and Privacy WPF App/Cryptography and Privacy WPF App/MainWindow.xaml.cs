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

namespace Cryptography_and_Privacy_WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            disclaimer();
        }

        void disclaimer()
        {
            ltoButton.Visibility = Visibility.Hidden;
            MessageBox.Show("Warning: While this program is pretty cool, and while it is a great jumping off point" +
                " for anyone looking to get into the world of cryptography, this will by no means make you an expert" +
                " on cryptography. It will, however, offer you some interesting information as well as some demos of" +
                "various cryptographic ciphers. So maybe you'll learn something that you could use to show off at..." +
                "dinner parties, or something", "Disclaimer",
                    MessageBoxButton.OK);
        }

        private void basicsButton_Click(object sender, RoutedEventArgs e)
        {
            new BasicsMenu().Show();
        }

        private void ltoButton_Click(object sender, RoutedEventArgs e)
        {
            new LTOMenu().Show();
        }

        private void basicEncryptionButton_Click(object sender, RoutedEventArgs e)
        {
            new BasicEncryptionMenu().Show();
        }

        private void advancedEncryptoinButton_Click(object sender, RoutedEventArgs e)
        {
            new AdvancedEncryptionMenu().Show();
        }

        private void otherThingsButton_Click(object sender, RoutedEventArgs e)
        {
            new ExtrasWindow().Show();
        }

        private void HistoryAndFunFactsButton_Click(object sender, RoutedEventArgs e)
        {
            new HistoryAndFunFactsWindow().Show();
        }
    }
}
