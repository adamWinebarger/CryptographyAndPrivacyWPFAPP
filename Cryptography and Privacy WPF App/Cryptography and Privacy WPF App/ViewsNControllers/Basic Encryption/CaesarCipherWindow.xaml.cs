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
    /// Interaction logic for CaesarCipherWindow.xaml
    /// </summary>
    public partial class CaesarCipherWindow : Window
    {
        private CaesarCipher caesarCipher = new CaesarCipher();

        public CaesarCipherWindow()
        {
            InitializeComponent();
            blurbTextBlock.Text = K.readFromFile(K.littleBlurbsDir + "CaesarCipher.txt");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnlyNumers(keyTextBox.Text))
                return;

            if (int.Parse(keyTextBox.Text) == 0)
            {
                outputTextBlock.Text = inputStringTextBox.Text;
                return;
            }

            int key = int.Parse(keyTextBox.Text);
            outputTextBlock.Text = caesarCipher.encrypt(inputStringTextBox.Text, key);
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isOnlyNumers(keyTextBox.Text))
                return;

            if (int.Parse(keyTextBox.Text) == 0)
            {
                outputTextBlock.Text = inputStringTextBox.Text;
                return;
            }

            int key = int.Parse(keyTextBox.Text) * -1;
            outputTextBlock.Text = caesarCipher.encrypt(inputStringTextBox.Text, key);
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.Equals(""))
                Clipboard.SetText(outputTextBlock.Text);
        }

        bool isOnlyNumers(string str)
        {
            if (K.onlyNumbersRegex.IsMatch(str))
                return true;

            MessageBox.Show(K.railFenceKeyError);
            return false;
        }
    }
}
