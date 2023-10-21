using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace Lab13;

public partial class N3 : Window
{
    public N3()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)   
    {
        string smth = BusName.Text;
        int ints = Convert.ToInt32(BusYear.Text);
        
        (string name, int year, int old, bool isNew) tuple = (smth,ints,DateTime.Now.Year-ints,DateTime.Now.Year-ints < 10);

        Output.Content = "Year > "+tuple.year +" Name > "+ tuple.name;
        
        WriteTupleToFile(@"C:\Users\itesl\LabWorksCS\CSLabWork13\Lab13\tuples.txt",tuple);
    }
    
    private void WriteTupleToFile(string path, (string name, int year, int old, bool isNew) tuple)
    {
        File.WriteAllText(path,File.ReadAllText(path)+ tuple.name+";"+tuple.year+";"+tuple.old+";"+tuple.isNew+"\n");
    }
    
    private List<(string name, int year, int old, bool isExpired)> Solution(string path)
    {

        string[] temp = File.ReadAllLines(path);

        List<(string name, int year, int old, bool isExpired)> tuples = new List<(string, int, int, bool)>();


        for (int j = 0; j < temp.Length; j++)
        {
            string[] secondtemp = temp[j].Split(";");
            if (Convert.ToBoolean(secondtemp[3]))
            {
                tuples.Add((secondtemp[0],Convert.ToInt32(secondtemp[1]),Convert.ToInt32(secondtemp[2]),Convert.ToBoolean(secondtemp[3])));
            }
                
        }
        
        return tuples;
    }

    private void sort_OnClick(object sender, RoutedEventArgs e)
    {
        List<(string name, int year, int old, bool isExpired)> tuples = Solution(@"C:\Users\itesl\LabWorksCS\CSLabWork13\Lab13\tuples.txt");

        Output.Content = null;
        foreach (var tuple in tuples)
        {
            Output.Content += "Old > "+tuple.old +" Name > "+ tuple.name + "\n";
        }
    }
}