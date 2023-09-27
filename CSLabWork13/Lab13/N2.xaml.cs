using System;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;

namespace Lab13;

public partial class N2 : Window
{
    public N2()
    {
        InitializeComponent();
    }
    
    

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        
        Material material = Material.None;

        try
        {
            if (int.Parse(Choose.Text) <= 7 && int.Parse(Choose.Text)>=1) {
                material = (Material)(int.Parse(Choose.Text) - 1);
            }

            switch (material)
            {
                case Material.Cotton:
                    Label.Content = "скатертину";
                    break;
                case Material.Paper:
                    Label.Content = "паперовий подарунок";
                    break;
                case Material.Leather:
                    Label.Content = "шкіряний подарунок";
                    break;
                case Material.Wax:
                    Label.Content = "свічки";
                    break;
                case Material.Wooden:
                    Label.Content = "дерев'яний подарунок";
                    break;
                case Material.Iron:
                    Label.Content = "залізний меч";
                    break;
                case Material.Copper:
                    Label.Content = "мідний подарунок";
                    break;
                default:
                    Label.Content = "невідомий подарунок";
                    break;
            }
        }
        catch (FormatException exception)
        {
            Label.Content = "bad things happend";
        }

    }

    private void Next_OnClick(object sender, RoutedEventArgs e)
    {
        N3 n3 = new N3();
        n3.Show();
    }
}