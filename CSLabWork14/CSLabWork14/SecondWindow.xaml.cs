using System;
using System.Collections.Generic;
using System.Windows;

namespace CSLabWork14;

public partial class SecondWindow : Window
{
    public static List<Item> items = new List<Item>();
    public SecondWindow()
    {
        InitializeComponent();
    }
    private void ToThirdTask(object sender, RoutedEventArgs e)
    {
        ThirdWindow thirdWindow = new ThirdWindow();
        thirdWindow.Show();
    }

    private void Solve(object sender, RoutedEventArgs e)
    {
        try
        {
            Item item = new Item(ProductName.Text,ProductCompany.Text,DateOnly.Parse(CreationDate.Text),DateOnly.Parse(ExpireDate.Text),Convert.ToInt32(Price.Text));
            items.Add(item);
        }
        catch (Exception exception)
        {
            Ouput.Text = "ERROR!";
        }
    }

    private void OutputAll(object sender, RoutedEventArgs e)
    {
        Ouput.Text = "";
        foreach (Item item in items)
        {
            Ouput.Text += item.ToString();
        }
    }

    private void ThisMonth(object sender, RoutedEventArgs e)
    {
        Ouput.Text = "";
        foreach (Item item in items)
        {
            if (item.createdDateTime.Month == DateTime.Now.Month)
            {
                Ouput.Text += item.ToString();
            }
        }
    }

    private void TwoDaysToExpire(object sender, RoutedEventArgs e)
    {
        Ouput.Text = "";
        int counter = 0;
        foreach (Item item in items)
        {
            if (DateTime.Now.Day-item.expireDateOnly.Day<2)
            {
                counter++;
                Ouput.Text += item.ToString();
            }
        }

        Ouput.Text += "\n \n" + counter + "items";
    }

    private void Expired(object sender, RoutedEventArgs e)
    {
        Ouput.Text = "";
        foreach (Item item in items)
        {
            if (DateTime.Now.Day<item.expireDateOnly.Day)
            {
                Ouput.Text += item.ToString();
            }
        }
    }

    private void FindPurest(object sender, RoutedEventArgs e)
    {
        Ouput.Text = "";

        Item output = items[0];
        
        foreach (Item item in items)
        {
            if (item.name == Find.Text)
            {
                if (DateTime.Now.Day-item.expireDateOnly.Day<2)
                {
                    output = item;
                }
            }
            
        }

        Ouput.Text = output.ToString();
    }
}