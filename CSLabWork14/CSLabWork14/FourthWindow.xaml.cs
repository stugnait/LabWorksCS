using System;
using System.Collections.Generic;
using System.Windows;

namespace CSLabWork14;

public partial class FourthWindow : Window
{
     public FourthWindow()
    {
        InitializeComponent();
    }


    private void Solve_Click(object sender, RoutedEventArgs e)
    {
        
        Dictionary<string, string> dict = new Dictionary<string, string>(); 

        dict.Add("txt","notepad.exe");
        dict.Add("cpp","clion.exe");
        dict.Add("cs","rider.exe");
        dict.Add("py","pycharm.exe");

        dict.Remove("txt");

        int counter = dict.Count;

        bool ckey = dict.ContainsKey("cpp");

        dict.Clear();

    }
}