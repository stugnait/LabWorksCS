﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Documents;

namespace Lab13
{
    
    public partial class MainWindow : Window
    {

        public string DataBasePath = @"C:\Users\itesl\LabWorksCS\CSLabWork13\Lab13\aeroflotDB.txt";
        
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
            
            string[] enterStrings = File.ReadAllLines(@"C:\Users\itesl\LabWorksCS\CSLabWork13\Lab13\aeroflotDB.txt");
            string output = "";
            List<AEROFLOT> aeroflots = new List<AEROFLOT>();

            for (int i = 0; i < enterStrings.Length; i++)
            {
                string[] temporary = enterStrings[i].Split(";");

                aeroflots.Add(new AEROFLOT(temporary[0], temporary[1], temporary[2]));

                 
            }

            List<AEROFLOT> sortedNames = aeroflots.OrderBy(Name => Name.CITY).ToList();
            //


            foreach (AEROFLOT aeroflot in sortedNames)
            {
                output += aeroflot +"\n";
            }
            Label.Content = output ;
        }
        

        private void ReloadDataBase()
        {
            string[] enterStrings = File.ReadAllLines(@"C:\Users\itesl\LabWorksCS\CSLabWork13\Lab13\aeroflotDB.txt");

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

        private void Find(object sender, RoutedEventArgs e)
        {
            string[] enterStrings = File.ReadAllLines(@"C:\Users\itesl\LabWorksCS\CSLabWork13\Lab13\aeroflotDB.txt");

            List<AEROFLOT> aeroflots = new List<AEROFLOT>();
            
            List<AEROFLOT> sorted = new List<AEROFLOT>();
            bool founded = false;
            string output = "";

            for (int i = 0; i < enterStrings.Length; i++)
            {
                string[] temporary = enterStrings[i].Split(";");

                aeroflots.Add(new AEROFLOT(temporary[0], temporary[1], temporary[2]));

                Label.Content = aeroflots[i];
                
                if (temporary[2] == FindCity.Text)
                {
                    output += temporary[0]+ " " + temporary[1] + " " + temporary[2] + "\n";
                    founded = true;
                }
            }

            if (founded)
            {
                Label.Content = output;
            }
            else
            {
                Label.Content = "Nemaye";

            }
        }
    }
}