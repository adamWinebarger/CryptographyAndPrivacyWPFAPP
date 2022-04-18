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
using System.Collections;
using System.IO;

namespace Cryptography_and_Privacy_WPF_App
{
    /// <summary>
    /// Interaction logic for AESWindow.xaml
    /// </summary>
    public partial class AESWindow : Window
    {
        AESEncryptor aesEncryptor = new AESEncryptor();
       private const string filepath = "AESTextFiles\\conceptEncryption.txt";

        private string text = "";
        public AESWindow()
        {
            InitializeComponent();

        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pt = inputStringTextBox.Text;
                write2File(inputStringTextBox.Text);

                aesEncryptor.EncryptFile(filepath, Encoding.ASCII.GetBytes(keyTextBox.Text));


                string[] lines = File.ReadAllLines(filepath);

                string output = "";

                foreach (string line in lines)
                    output += line;

                outputTextBlock.Text = output;
                text = output;
            } catch
            {
                MessageBox.Show("Something went wrong. At a guess. You don't have a valid key in place. Have " +
                    "you tried an online AES key generator?", "Encryption Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                byte[] b = Encoding.ASCII.GetBytes(keyTextBox.Text);
                string[] lines = aesEncryptor.DecryptFile(filepath, b);

                string output = "";

                foreach (string line in lines)
                    output += line;

                //outputTextBlock.Text = op;
                outputTextBlock.Text = output;

                //aesEncryptor.EncryptFile("")
            }
            catch
            {
                MessageBox.Show("Something went wrong. At a guess. You don't have a valid key in place. " +
                    "Have you tried an online AES key generator?\n\nAlso worth noting that you can't go " +
                    "backwards here. So if you're trying to 'decrypt' some plain-text, it won't work. In " +
                    "fact, it would probably crash if this catchment wasn't here", "Decryption Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.Equals(""))
                Clipboard.SetText(outputTextBlock.Text);
        }

        bool checkValidKey(string key)
        {
            byte[] stringasByte = Encoding.ASCII.GetBytes(key);

            BitArray ba = new BitArray(stringasByte.Reverse().ToArray());

            if (ba.Length != 128 && ba.Length != 256)
                return false;

            return true;
        }

        void write2File(string input)
        {
            using (StreamWriter writer = File.CreateText(filepath))
            {
                writer.WriteLine(input);
            }
        }
    }
}
