using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AS1Window.xaml
    /// </summary>
    public partial class AS1Window : Window
    {
        Regex numbersOnly = new Regex(@"^\d+$"); //checks all character in a string to make sure they're numbers only

        public AS1Window()
        {
            InitializeComponent();
        }

        private void input1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (input1TextBox.Text != "" && !numbersOnly.IsMatch(input1TextBox.Text))
            {
                MessageBox.Show("Error! Invalid input detected.", null);
                input1TextBox.Text = "";
            }
        }

        private void input2TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (input2TextBox.Text != "" && !numbersOnly.IsMatch(input2TextBox.Text))
            {
                MessageBox.Show("Error! Invalid input detected", null);
                input2TextBox.Text = "";
            }
        }

        private void checkPrimeButton_Click(object sender, RoutedEventArgs e)
        {
            long value;

            if (input1TextBox.Text.Equals(""))
            {
                MessageBox.Show("No input detected.", null);
                return;
            }

            value = Convert.ToInt64(input1TextBox.Text);

            if (checkPrime(value))
            {
                MessageBox.Show("Number in question is prime");
            } else
            {
                MessageBox.Show("The number in question is not prime");
            }

            
        }

        bool checkPrime(long v)
        {
            long value = v;

            List<long> divisibleValues = new List<long>();

            for (long i = 1; i <= value; i++)
            {
                if (value % i == 0)
                {
                    divisibleValues.Add(i);

                    if (divisibleValues.Count > 2)
                        return false;
                }
            }

            if (divisibleValues.Count == 1)
            {
                MessageBox.Show("The value input is 1", null);
                return false;
            }

            return true;
        }

        long check4NearestPrimes(long n, string upDown)
        {
            long value;

            if (upDown.Equals("upper"))
            {
                for (long i = n; i < long.MaxValue; i++)
                {
                    if (checkPrime(i))
                        return i;
                }
                return -1;
            } else if (upDown.Equals("lower"))
            {
                for (long j = n; j > 1; j--)
                {
                    if (checkPrime(j))
                        return j;
                }
                return -1;
            } else
                return -999;
        }
    }
}
