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

namespace Cryptography_and_Privacy_WPF_App
{
    /// <summary>
    /// Interaction logic for BasicsMenu.xaml
    /// </summary>
    public partial class BasicsMenu : Window
    {
        private string directory = "BasicTexts";

        private string[] textFiles = { "WhatIsEncryption", "EncryptionvsEncoding", "Origins" };

        private BigBlurbRelevantInfo whatIsEncryption, origins, encodingVencryption, steganogrpahy;

        public BasicsMenu()
        {
            InitializeComponent();
            generateStructs();

        }

        private void whatIsEncryptionButton_Click(object sender, RoutedEventArgs e)
        {
            new BigBlurbWindow(whatIsEncryption).Show();
        }

        private void differenceButton_Click(object sender, RoutedEventArgs e)
        {
            new BigBlurbWindow(encodingVencryption).Show();
        }

        private void originButton_Click(object sender, RoutedEventArgs e)
        {
            //titleLabel.Content = originButton.Content;
            //changeTextBlock(2);
            new BigBlurbWindow(origins).Show();
        }

        private void steganographyButton_Click(object sender, RoutedEventArgs e)
        {
            //titleLabel.Content = steganographyButton.Content;
            //infoBlock.Text = "There's nothing here... yet";

            new BigBlurbWindow(steganogrpahy).Show();
        }

        void changeTextBlock(int input)
        {
            string path = String.Format("{0}\\{1}.txt", directory, textFiles[input]);
            string textBlockText = File.ReadAllText(path);
            infoBlock.Text = textBlockText;
        }

        private void generateStructs()
        {
            //File.Create(K.basicsBlurbsDir + "test.txt");
            whatIsEncryption = new BigBlurbRelevantInfo("What is Encryption?", 
                parseInfoFromTextFile(K.basicTextsDir + "WhatIsEncryption.txt"), false, false);

            //whatIsEncryption.image1FilePath = "enc4.jpg";
            //whatIsEncryption.image1Visible = true;

            origins = new BigBlurbRelevantInfo("Cryptography: Origins",
                parseInfoFromTextFile(K.basicTextsDir + "Origins.txt"), false, false);

            encodingVencryption = new BigBlurbRelevantInfo("Encoding vs. Encryption",
                parseInfoFromTextFile(K.basicTextsDir + "EncryptionvsEncoding.txt"), false, false);

            steganogrpahy = new BigBlurbRelevantInfo("Steganography",
                parseInfoFromTextFile(K.basicTextsDir + "steganography.txt"), false, false);
        }

        string parseInfoFromTextFile(string filePath)
        {
            string output = "";

            if (File.Exists(filePath))
            {
                string lines = File.ReadAllText(filePath);
                output += lines;
            }

            return output;
           
        }
    }
}
