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
using System.IO;
using Microsoft.Win32;

namespace Cryptography_and_Privacy_WPF_App
{
    /// <summary>
    /// Interaction logic for AESChatWindow.xaml
    /// </summary>
    public partial class AESChatWindow : Window
    {
        private AESEncryptor aesEncryptor = new AESEncryptor();

        private string filepath = "AESTextFiles\\chatEncryption.txt";

        byte[] key;

        public AESChatWindow()
        {
            InitializeComponent();

        }

        private void encryptButton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pt = chatBox.Text;

                if (pt.Equals(null) || pt.Equals(""))
                    return;

                checkRadioButtons();
                write2File(chatBox.Text);

                aesEncryptor.EncryptFile(filepath, key);


                string[] lines = File.ReadAllLines(filepath);

                string output = "";

                foreach (string line in lines)
                    output += line;

                chatBox.Text = output;

            }
            catch
            {
                MessageBox.Show("Something went wrong. At a guess. You don't have a valid key in place. Have " +
                    "you tried an online AES key generator?", "Encryption Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void encryptButton2_Click(object sender, RoutedEventArgs e)
        {
            checkRadioButtons();
            SaveFileDialog sd1 = new SaveFileDialog();
            //sd1.Filter = "*.txt";
            sd1.Title = "Save an image file";

            string[] lines = File.ReadAllLines(filepath);

            string output = "";

            foreach (string line in lines)
                output += line;

            chatBox.Text = output;

            //sd1.ShowDialog();

            if (sd1.ShowDialog() == true && sd1.FileName != "")
            {
                if (!File.Exists(sd1.FileName))
                    File.Copy(filepath, sd1.FileName);
                else
                {
                    File.Delete(sd1.FileName);
                    File.Copy(filepath, sd1.FileName);
                }
                
            }

            




        }

        private void decryptButton1_Click(object sender, RoutedEventArgs e)
        {
            checkRadioButtons();

            if (key == null)
                return;

            try
            {
                //string ct = chatBox.Text;
                //checkRadioButtons();

                string[] output = aesEncryptor.DecryptFile(filepath, key);
                string op = "";

                for (int i = 0; output != null && i < output.Length; i++)
                {
                    op += output[i];
                }

                //outputTextBlock.Text = op;
                chatBox.Text = op;
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

        private void decryptButton2_Click(object sender, RoutedEventArgs e)
        {
            checkRadioButtons();

            if (key == null)
                return;

            OpenFileDialog od1 = new OpenFileDialog();

            od1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            
            string output = "";

            try
            {
                if (od1.ShowDialog() == true)
                {
                   // MessageBox.Show(od1.FileName);
                    //MessageBox.Show("OD1 has value");
                    string[] lines2 = aesEncryptor.DecryptFile(od1.FileName, key);
                    for (int i = 0; lines2 != null && i < lines2.Length; i++)
                    {
                        output += lines2[i];
                        //MessageBox.Show(lines2[i]);
                    }

                    outputTextBlock.Text = output;
                }
            } catch
            {
                MessageBox.Show("Something went wrong");
            }

            

        }

        void checkRadioButtons()
        {

            string[] keyChecker = { @"D:/Key.txt", @"E:/Key.txt", @"F:/Key.txt", @"G:/Key.txt", @"H:/Key.txt" };
            byte[] b = null;

            if (usbButton.IsChecked == true)
            {  
                foreach (string key in keyChecker)
                {
                    if (File.Exists(key))
                    {
                        string[] lines = File.ReadAllLines(key);
                        b = Encoding.ASCII.GetBytes(lines[0]);

                    }
                }

                if (b == null)
                    MessageBox.Show("No valid usb detected. If you are using your own USB stick, make sure you have a file called 'key.txt' saved in the local root of the device");


                key = b;
            } else
            {
                string keyText = keyInputLabel.Text;
                key = Encoding.ASCII.GetBytes(keyInputLabel.Text);
            }
        }

        private void mvOutputButton_Click(object sender, RoutedEventArgs e)
        {
            chatBox.Text = outputTextBlock.Text;
            outputTextBlock.Text = "";
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
