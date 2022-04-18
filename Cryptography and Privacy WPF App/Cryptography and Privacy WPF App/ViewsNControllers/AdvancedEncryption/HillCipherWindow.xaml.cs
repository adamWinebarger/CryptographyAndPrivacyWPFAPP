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
    /// Interaction logic for HillCipherWindow.xaml
    /// </summary>
    public partial class HillCipherWindow : Window
    {
        HillCipher hillCipher = new HillCipher();

        public HillCipherWindow()
        {
            InitializeComponent();
            blurbTextBlock.Text = K.readFromFile(K.littleBlurbsDir + "Hill.txt");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            string text = conformStrings(inputStringTextBox.Text),
                key = conformStrings(keyTextBox.Text);

            if (text.Equals("") || key.Equals(""))
                return;

            key = keyCheck(key);

            string output = hillCipher.hillCipher(text, key);
            outputTextBlock.Text = output;

        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        string conformStrings(string input)
        {
            string output = "", i2 = input.ToUpper();

            foreach (char c in i2)
                if (Char.IsUpper(c))
                    output += c;

            return output;
        }

        string keyCheck(string key)
        {
            if (key.Length % 3 != 0)
                key += 'A';

            if (key.Length % 3 != 0)
                key += 'B';

            return key;
        }
    }
}
