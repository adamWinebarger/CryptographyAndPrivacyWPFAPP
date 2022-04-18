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
    /// Interaction logic for AtbashWindow.xaml
    /// </summary>
    public partial class AtbashWindow : Window
    {
        private AtbashCipher atbashCipher = new AtbashCipher();

        public AtbashWindow()
        {
            InitializeComponent();
            keyTextBox.Visibility = Visibility.Hidden;
            KeyLabel.Visibility = Visibility.Hidden;
            blurbTextBlock.Text = K.readFromFile(K.littleBlurbsDir + "Atbash.txt");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (validText())
                outputTextBlock.Text = atbashCipher.encrypt(inputStringTextBox.Text);
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (validText())
            {
                outputTextBlock.Text = atbashCipher.encrypt(inputStringTextBox.Text);
                MessageBox.Show("Yeah... uh, these buttons do the same thing for this particular cipher");
            }
                

        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.Equals(""))
                Clipboard.SetText(outputTextBlock.Text);
        }

        bool validText()
        {
            if (inputStringTextBox.Text.Equals("") || inputStringTextBox.Text.Equals(null) ||
                inputStringTextBox.Text.Length <= 1)
                return false;
            return true;
        }
    }
}
