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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Number_Guessing_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int minValue;
        int maxValue;
        int randomNumber;
        int userNumber;
        int count = 5;

        private void SetTheRange_Click(object sender, RoutedEventArgs e)
        {


            string minimumValue = MinimumValueInput.Text;
            string maximumValue = MaximumValueInput.Text;


            if (string.IsNullOrEmpty(MinimumValueInput.Text))
            {
                MessageBox.Show("You didn't enter minimum value");
                return;

            }
            if (!int.TryParse(minimumValue, out minValue))
            {
                MessageBox.Show("You entered invalid minimum value. Please try again");
                MinimumValueInput.Clear();
                return;
            }


            if (string.IsNullOrEmpty(MaximumValueInput.Text))
            {
                MessageBox.Show("You didn't enter maximum value");
                return;

            }

            if (!int.TryParse(maximumValue, out maxValue))
            {
                MessageBox.Show("You entered invalid maximum value. Please try again");
                MaximumValueInput.Clear();
                return;
            }

            Random random = new Random();

            randomNumber = random.Next(minValue, maxValue + 1);

            label.Content = $"Now please enter number between {minValue} and {maxValue}";
        }



        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernumberInput.Text))
            {
                MessageBox.Show("You didn't enter the number");
                return;
            }

            if (!int.TryParse(UsernumberInput.Text, out userNumber))
            {
                MessageBox.Show("You entered invalid number. Please try again");
                UsernumberInput.Clear();

                return;
            }

            if (count == 0 && userNumber != randomNumber)
            {
                MessageBox.Show($"You lost. The right number is {randomNumber}");
                UsernumberInput.Clear();
                MinimumValueInput.Clear();
                MaximumValueInput.Clear();
                label.Content = "Now please enter number between minValue and maxValue";
                count = 5;
                return;
            }

            if (userNumber < minValue || userNumber > maxValue)
            {
                MessageBox.Show("You didn't enter number between right range. Please enter again");
                UsernumberInput.Clear();
                return;
            }


            if (userNumber < randomNumber)
            {
                if (count == 1)
                {
                    MessageBox.Show($"Wrong desicion. You have {count} chance. Please enter higher number");

                }
                else
                {
                    MessageBox.Show($"Wrong desicion. You have {count} chances. Please enter higher number");

                }
                UsernumberInput.Clear();
                count--;

            }
            else if (userNumber > randomNumber)
            {
                if (count == 1)
                {
                    MessageBox.Show($"Wrong desicion. You have {count} chance. Please enter higher number");

                }
                else
                {
                    MessageBox.Show($"Wrong desicion. You have {count} chances. Please enter higher number");

                }
                UsernumberInput.Clear();
                count--;

            }
            else
            {
                MessageBox.Show($"Congratulations. You found right number at {6 - count}th time");
                UsernumberInput.Clear();
                MinimumValueInput.Clear();
                MaximumValueInput.Clear();
                label.Content = "Now please enter number between minValue and maxValue";
                count = 5;


            }


        }



    }
}
