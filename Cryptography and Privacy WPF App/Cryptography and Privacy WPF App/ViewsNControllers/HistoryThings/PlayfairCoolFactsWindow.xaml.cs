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
    /// Interaction logic for PlayfairCoolFactsWindow.xaml
    /// </summary>
    public partial class PlayfairCoolFactsWindow : Window
    {
        public PlayfairCoolFactsWindow(LittleBlurb lrb)
        {
            InitializeComponent();
            titleLabel.Content = lrb.title;
            blurbTextBlock.Text = lrb.text;


        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void otherButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I Agree!");
            this.Close();
        }
    }
}
