using System;
 using System.Collections.Generic;
 using System.Windows;
 
 namespace CSLabWork14;
 
 public partial class ThirdWindow : Window
 {
     
     
     public ThirdWindow()
     {
         InitializeComponent();
     }
     public void HashBuild()
   {
        HashSet<int> firstHashSet = new HashSet<int>()
           {
               1,2,3,4,5,8,9,10
           };
        HashSet<int> secondHashSet = new HashSet<int>()
       {
           6,7,8,9,10
       };
   }
     private void Solve(object sender, RoutedEventArgs e)
     {
         HashSet<int> firstHashSet = new HashSet<int>()
         {
             1,2,3,4,5,8,9,10
         };
         HashSet<int> secondHashSet = new HashSet<int>()
         {
             6,7,8,9,10
         };
         try
         {
             HashBuild();
             firstHashSet.IntersectWith(secondHashSet);
             HashBuild();
             firstHashSet.UnionWith(secondHashSet);
             HashBuild();
             firstHashSet.ExceptWith(secondHashSet);
             HashBuild();
             firstHashSet.SymmetricExceptWith(secondHashSet);
         }
         catch (Exception exception)
         {
             Ouput.Text = "ERROR!";
         }
     }
 
     private void ToFourthTask(object sender, RoutedEventArgs e)
     {
         FourthWindow fourthWindow = new FourthWindow();
         fourthWindow.Show();
     }
 } 