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
    /// Interaction logic for VigenerWindow.xaml
    /// </summary>
    public partial class VigenerWindow : Window
    {
        private Vigener vigener = new Vigener();
        private string text, key, cipherText = "";

        public VigenerWindow()
        {
            InitializeComponent();
            blurbTextBlock.Text = K.readFromFile(K.littleBlurbsDir + "vigener.txt");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            text = conformString(inputStringTextBox.Text.ToUpper());
            key = conformString(keyTextBox.Text.ToUpper());

            if (checkValidEntries())
            {
                key = vigener.generateKey(text, key);
                outputTextBlock.Text = vigener.cipherText(text, key);
                cipherText = outputTextBlock.Text;
            }

        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!cipherText.Equals(""))
                outputTextBlock.Text = vigener.originalText(cipherText, key);


        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.Equals(""))
                Clipboard.SetText(outputTextBlock.Text);
        }

        bool checkValidEntries()
        {
            if (key.Equals("") || key.Equals(null))
            {
                showErrorMessage(2);
                return false;
            }

            if (text.Equals("") || text.Equals(null))
            {
                showErrorMessage(1);
                return false;
            }

            return true;
        }

        void showErrorMessage(int which)
        {
            string errorMessage = "";

            switch (which)
            {
                case 1:
                    errorMessage = K.VigenerTextError;
                    break;
                case 2:
                    errorMessage = K.VigenereKeyError;
                    break;
                default:
                    errorMessage = K.unknownError1;
                    break;
            }

            MessageBox.Show(errorMessage, null);
        }

        private string conformString(string str)
        {
            string newString = K.onlyUppersRegex.Replace(str, String.Empty);

            return newString;
        }


    }
}
