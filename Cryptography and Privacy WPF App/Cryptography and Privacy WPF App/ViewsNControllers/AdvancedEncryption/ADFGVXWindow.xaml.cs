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
    /// Interaction logic for ADFGVXWindow.xaml
    /// </summary>
    public partial class ADFGVXWindow : Window
    {

        private ADFGVXCipher2 adfgvx;
        bool encryptButtonpressed = false;

        public ADFGVXWindow()
        {
            InitializeComponent();
            blurbTextBlock.Text = K.readFromFile(K.littleBlurbsDir + "ADFGVX.txt");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = conform(inputStringTextBox.Text);
                string key = conform(keyTextBox.Text);

                if (!encryptButtonpressed)
                {
                    adfgvx = new ADFGVXCipher2(key);
                    encryptButtonpressed = true;
                }

                outputTextBlock.Text = adfgvx.encode(text);
            } catch
            {
                MessageBox.Show("Error! Something went wrong");
            }
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cipherText = conform(inputStringTextBox.Text);
                string key = conform(keyTextBox.Text);

                

                outputTextBlock.Text = adfgvx.decode(cipherText);
            } catch
            {
                MessageBox.Show("Error. Something went wrong. Are you sure you loaded the table?");
            }
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.Equals(""))
                Clipboard.SetText(outputTextBlock.Text);
        }

        string conform(string input)
        {
            string output = "";

            foreach (char c in input)
            {
                if (Char.IsDigit(c) || Char.IsUpper(Char.ToUpper(c)))
                    output += Char.ToUpper(c);
            }

            return output;
        }
    }
}
