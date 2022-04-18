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
    /// Interaction logic for AffineCipherWindow.xaml
    /// </summary>
    public partial class AffineCipherWindow : Window
    {
        AffineCipher affineCipher;
        int a, b;

        public AffineCipherWindow()
        {
            InitializeComponent();
            blurbTextBlock.Text = K.readFromFile(K.littleBlurbsDir + "Affine.txt");
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!bothKeyTextBoxesHaveValidInputs())
                return;

            a = int.Parse(aTextBox.Text);
            b = int.Parse(bTextBox.Text);

            affineCipher = new AffineCipher(a, b);
            
            if(!inputStringTextBox.Text.Equals("") && !inputStringTextBox.Text.Equals(null))
                outputTextBlock.Text = affineCipher.encryptMessage(inputStringTextBox.Text.ToUpper());
            
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (!bothKeyTextBoxesHaveValidInputs())
                return;

            a = int.Parse(aTextBox.Text);
            b = int.Parse(bTextBox.Text);

            affineCipher = new AffineCipher(a, b); //this is to prevent any nullPointer exceptions 

            if (!inputStringTextBox.Text.Equals("") && !inputStringTextBox.Text.Equals(null))
                outputTextBlock.Text = affineCipher.decryptMessage(inputStringTextBox.Text.ToUpper());
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.Equals(""))
                Clipboard.SetText(outputTextBlock.Text);
        }

        bool bothKeyTextBoxesHaveValidInputs()
        {
            if (!K.onlyNumbersRegex.IsMatch(aTextBox.Text) || !K.onlyNumbersRegex.IsMatch(bTextBox.Text)) {
                MessageBox.Show(K.railFenceKeyError);
                return false;
            }

            if (int.Parse(aTextBox.Text) < 1 || int.Parse(bTextBox.Text) < 1)
            {
                MessageBox.Show(K.badNegativeNumberError);
                return false;
            }

            return true;
        }
    }
}
