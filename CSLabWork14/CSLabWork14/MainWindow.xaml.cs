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

namespace CSLabWork14
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

        private void ToSecondTask(object sender, RoutedEventArgs e)
        {
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
        }

        private void Solve(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeSpan firsTimeOnly = TimeSpan.Parse(FirstProcedure.Text);
                TimeSpan secondTimeOnly = TimeSpan.Parse(SecondProcedure.Text);
                TimeSpan timeNeeded = secondTimeOnly - firsTimeOnly;

                string stringOutput = firsTimeOnly.ToString()+'\n'+secondTimeOnly+'\n';
                
                for (int i = 1; i < Convert.ToInt32(Counter.Text); i++)
                {
                    stringOutput += (secondTimeOnly + timeNeeded*i).ToString()+'\n';
                }

                Ouput.Content = stringOutput;
            }
            catch (Exception exception)
            {
                Ouput.Content = "ERROR!";
            }
        }
    }
}