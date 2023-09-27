using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace Lab13
{
    
    public partial class MainWindow : Window
    {

        public string DataBasePath = @"C:\Users\itesl\RiderProjects\CSLabWork13\Lab13\aeroflotDB.txt";
        
        public MainWindow()
        {
            InitializeComponent();
            ReloadDataBase();
        }

        private void AddNew_OnClick(object sender, RoutedEventArgs e)
        {
            
            AEROFLOT aeroflot = new AEROFLOT(CityInput.Text, NumInput.Text, TypeInput.Text);
            
            File.WriteAllText(DataBasePath,File.ReadAllText(DataBasePath) + aeroflot.ToSaveFormat());

            ReloadDataBase();   
        }

        private void SortByAlphabet_OnClick(object sender, RoutedEventArgs e)
        {
            
            string[] enterStrings = File.ReadAllLines(@"C:\Users\itesl\RiderProjects\CSLabWork13\Lab13\aeroflotDB.txt");

            List<AEROFLOT> aeroflots = new List<AEROFLOT>();

            for (int i = 0; i < enterStrings.Length; i++)
            {
                string[] temporary = enterStrings[i].Split(";");

                aeroflots.Add(new AEROFLOT(temporary[0], temporary[1], temporary[2]));

                Label.Content = aeroflots[i];
            }

            
            aeroflots = aeroflots.OrderBy(s => s.CITY).ToList();

            DataGrid.ItemsSource = aeroflots;
        }

        private void ReloadDataBase()
        {
            string[] enterStrings = File.ReadAllLines(@"C:\Users\itesl\RiderProjects\CSLabWork13\Lab13\aeroflotDB.txt");

            List<AEROFLOT> aeroflots = new List<AEROFLOT>();

            for (int i = 0; i < enterStrings.Length; i++)
            {
                string[] temporary = enterStrings[i].Split(";");

                aeroflots.Add(new AEROFLOT(temporary[0], temporary[1], temporary[2]));

               Label.Content = aeroflots[i];
            }
            
            DataGrid.ItemsSource = aeroflots;
        }

        private void ToSecond_Click(object sender, RoutedEventArgs e)
        {
            N2 n2 = new N2();
            n2.Show();
        }
    }
}