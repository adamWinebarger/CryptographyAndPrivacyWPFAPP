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
    /// Interaction logic for BabbageWindwo.xaml
    /// </summary>
    public partial class BabbageWindwo : Window
    {
        public BabbageWindwo(LittleBlurb lrb)
        {
            InitializeComponent();
            titleLabel.Content = lrb.title;
            blurbTextBlock.Text = lrb.text;
        }

        private void otherButton_Click(object sender, RoutedEventArgs e)
        {
            if (otherButton.Content.Equals("Neat"))
                MessageBox.Show("I agree");

            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }
    }
}
