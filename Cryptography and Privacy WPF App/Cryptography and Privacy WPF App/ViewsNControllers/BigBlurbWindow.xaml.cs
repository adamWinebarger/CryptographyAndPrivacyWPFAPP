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
    /// Interaction logic for BigBlurbWindow.xaml
    /// </summary>
    public partial class BigBlurbWindow : Window
    {


        public BigBlurbWindow(BigBlurbRelevantInfo brb)
        {
            InitializeComponent();
            imageslot1.Visibility = Visibility.Hidden;
            imageslot2.Visibility = Visibility.Hidden;

            buildOut(brb);
            //InitializeComponent();
        }

        public BigBlurbWindow(LittleBlurb lrb)
        {
            InitializeComponent();
            imageslot1.Visibility = Visibility.Hidden;
            imageslot2.Visibility = Visibility.Hidden;

            titleLabel.Content = lrb.title;
            blurbTextBlock.Text = lrb.text;
        }


        private void buildOut(BigBlurbRelevantInfo brb)
        {
            titleLabel.Content = brb.title;
            blurbTextBlock.Text = brb.blurbText;

            if (brb.image1Visible)
            {

                BitmapImage bi1 = new BitmapImage();
                bi1.BeginInit();
                //bi1.UriSource = new Uri(brb.image1FilePath, UriKind.RelativeOrAbsolute);
                //bi1.EndInit();
                //imageslot1.Source = bi1;

                imageslot1.Source = new BitmapImage(new Uri(String.Format(@"\Assets\Images\{0}", brb.image1FilePath), UriKind.Relative));

                //Uri fileUri = new Uri(brb.image1FilePath, UriKind.Relative);
                //imageslot1.Source = new BitmapImage(fileUri);
                imageslot1.Visibility = Visibility.Visible;
            }

            if (brb.image2Visible)
            {
                Uri fileUri = new Uri(brb.image2FilePath);
                imageslot2.Source = new BitmapImage(fileUri);
                imageslot2.Visibility = Visibility.Visible;
            }

            if (brb.modifyOKButtonText)
                okButton.Content = brb.okButtonText;

            if (brb.modifyNeatButtonText)
                otherButton.Content = brb.modifyNeatButtonText;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void otherButton_Click(object sender, RoutedEventArgs e)
        {
            if (otherButton.Content.Equals("Neat"))
                MessageBox.Show("I agree");

            this.Close();
        }
    }
}
