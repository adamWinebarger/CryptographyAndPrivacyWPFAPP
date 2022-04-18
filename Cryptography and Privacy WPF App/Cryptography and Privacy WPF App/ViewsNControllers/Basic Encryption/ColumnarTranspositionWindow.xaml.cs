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
    /// Interaction logic for ColumnarTranspositionWindow.xaml
    /// </summary>
    public partial class ColumnarTranspositionWindow : Window
    {

        ColumnarTransposition2 columnarTranspositionCipher = new ColumnarTransposition2();
        public ColumnarTranspositionWindow()
        {
            InitializeComponent();
            blurbTextBlock.Text = K.readFromFile(K.littleBlurbsDir + "ColumnarTransposition.txt");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
           // columnarTranspositionCipher.setPermutationOrder(keyTextBox.Text);

            if (!inputStringTextBox.Text.Equals("") && !inputStringTextBox.Text.Equals(null) &&
                !keyTextBox.Text.Equals(null) && !keyTextBox.Text.Equals(""))
            {
                string text = inputStringTextBox.Text.ToUpper();
                string key = keyTextBox.Text.ToUpper();

                outputTextBlock.Text = columnarTranspositionCipher.encrypt(text, key);
            }
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!inputStringTextBox.Text.Equals("") && !inputStringTextBox.Text.Equals(null) &&
                !keyTextBox.Text.Equals(null) && !keyTextBox.Text.Equals(""))
            {
                string text = inputStringTextBox.Text.ToUpper();
                string key = keyTextBox.Text.ToUpper();

                outputTextBlock.Text = columnarTranspositionCipher.decrypt(text, key);
            }
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.Equals(""))
                Clipboard.SetText(outputTextBlock.Text);
        }
    }
}
