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
    /// Interaction logic for HistoryAndFunFactsWindow.xaml
    /// </summary>
    public partial class HistoryAndFunFactsWindow : Window
    {
        LittleBlurb scytale, playFair, babbage, napoleon, mlk, enigma;

        public HistoryAndFunFactsWindow()
        {
            InitializeComponent();
            generateStructs();
        }

        private void EarlyCryptogrpaphyButton_Click(object sender, RoutedEventArgs e)
        {
            new BigBlurbWindow(scytale).Show();
        }

        private void playfairButton_Click(object sender, RoutedEventArgs e)
        {
            new PlayfairCoolFactsWindow(playFair).Show();
        }

        private void babbageButton_Click(object sender, RoutedEventArgs e)
        {
            new BabbageWindwo(babbage).Show();
        }

        private void napoleonicButton_Click(object sender, RoutedEventArgs e)
        {
            new NapoleonWindow(napoleon).Show();
        }

        private void mlkButton_Click(object sender, RoutedEventArgs e)
        {
            new MLKWindow(mlk).Show();
        }

        private void enigmaButtton_Click(object sender, RoutedEventArgs e)
        {
            new EnigmaCoolFactsWindoow(enigma).Show();
        }

        void generateStructs()
        {
            scytale = new LittleBlurb("ScyTale & Early Cryptography", readFromFile(K.historyDir + "scytale.txt"));
            playFair = new LittleBlurb("Playfair Cipher Shakes Things Up", readFromFile(K.historyDir + "Playfair.txt"));
            babbage = new LittleBlurb(babbageButton.Content.ToString(), readFromFile(K.historyDir + "BabbageBreaksVigenere.txt"));
            napoleon = new LittleBlurb("Napoleon's Cryptologic Follies", readFromFile(K.historyDir + "Napoleon.txt"));
            mlk = new LittleBlurb("Wiretapping of MLK:\nA Surprisingly Good Argument for Strong Ciphers", readFromFile(K.historyDir + "MLK.txt"));
            enigma = new LittleBlurb("The enigma machine", readFromFile(K.historyDir + "Enigma.txt"));
        }

        string readFromFile(string filePath)
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
