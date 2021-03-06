﻿using System;
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
using System.IO;
using System.Collections.ObjectModel;

namespace Straczek_SEW_Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue<object> queue = new Queue<object>();
        ObservableCollection<object> obsCollection = new ObservableCollection<object>();
        public MainWindow()
        {
            
            InitializeComponent();
            lb1.ItemsSource = obsCollection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader readcsv = new StreamReader("Songs.csv");
           
            while (!readcsv.EndOfStream)
            {
                    //Als Überprüfung um welchen Musikplayer es sich handelt habe ich die Property ID vergeben. Falls die ID == 1 dann ist es ein MP3-Player, 
                    //falls ID == 2 dann ist es eine CD und falls ID == 3 dann ist es ein Tonbandgerät. Die ID muss an der position 0(also am anfang) in der CSV Datei enhalten werden.
                string line = readcsv.ReadLine();
                string[] parts = line.Split(',');
                    int parts0 = int.Parse(parts[0]);
                    if (parts0 == 1)
                    {
                        
                            Mp3_Player mp3 = new Mp3_Player(parts0, parts[1], parts[2], parts[3], double.Parse(parts[4]), double.Parse(parts[5]));
                        obsCollection.Add(mp3);
                       
                    }
                    else if (parts0 == 2)
                    {
                        CD_Player cd = new CD_Player(parts0, parts[1], parts[2], parts[3], double.Parse(parts[4]));

                        obsCollection.Add(cd);
                    }
                    else
                    {
                        Tonbandgerät ton = new Tonbandgerät(parts0, parts[1], parts[2], parts[3], parts[4]);

                        obsCollection.Add(ton);
                    }
                   

            }
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Datei wurde nicht gefunden");
            }

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            //  File.WriteAllText("Songs.csv", tb1.Text);
            StreamWriter writer = new StreamWriter("Songs.csv",true);
            writer.WriteLine(tb1.Text);
            writer.Close();
            tb1.Text = "";
        }

      

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = lb1.SelectedIndex;
                //lb2.Items.Add(obsCollection[a]);
                queue.Enqueue(lb2.Items.Add(obsCollection[a]));
            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("Bitte einen Song für die Playlist auswählen!");
            }

             
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            queue.Dequeue();
                int count = 0;

                lb2.Items.RemoveAt(count);
                count++; 
            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Keine Einträge in der Playlist vorhanden");
            }
            
            
        }

        private void tb1_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wichtig!!!  Achte darauf, dass du die richtige Schreibweise behälst.");
        }
    }
}
