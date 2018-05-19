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
using System.IO;
using System.Collections.ObjectModel;

namespace Straczek_SEW_Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader readcsv = new StreamReader("csv.csv");
           
            while (!readcsv.EndOfStream)
            {
                    //Als Überprüfung um welchen Musikplayer es sich handelt habe ich die Property ID vergeben. Falls die ID == 1 dann ist es ein MP3-Player, 
                    //falls ID == 2 dann ist es eine CD und falls ID == 3 dann ist es ein Tonbandgerät. Die ID muss an der position 0(also am anfang) in der CSV Datei enhalten werden.
                string line = readcsv.ReadLine();
                string[] parts = line.Split(',');
                ObservableCollection<object> obsCollection = new ObservableCollection<object>(parts);
                    if (int.Parse(parts[0]) == 1)
                    {
                        
                            Mp3_Player mp3 = new Mp3_Player(int.Parse(parts[0]), parts[1], parts[2], parts[3], double.Parse(parts[4]), double.Parse(parts[5]));
                      
                        lb1.Items.Add("ID: " + parts[0] + "  Titel: " + parts[1] + "  Künstler: " + parts[2] + "  Album: " + parts[3] + "  Länge: " + parts[4] + "min" + "  Größe: " + parts[5]+"MB");
                    }
                    else if (int.Parse(parts[0]) == 2)
                    {
                        CD_Player cd = new CD_Player(int.Parse(parts[0]), parts[1], parts[2], parts[3], double.Parse(parts[4]));
                       
                        lb1.Items.Add("ID: " + parts[0] + "  Titel: " + parts[1] + "  Künstler: " + parts[2] + "  Album: " + parts[3] + "  Länge: " + parts[4] + "min");
                    }
                    else
                    {
                        Tonbandgerät ton = new Tonbandgerät(int.Parse(parts[0]), parts[1], parts[2], parts[3], parts[4]);
                        
                        lb1.Items.Add("ID: " + parts[0] + "  Titel: " + parts[1] + "  Künstler: " + parts[2] + "  Album: " + parts[3] + "  Tonband: " + parts[4]);
                    }
                    
                foreach (var item in obsCollection)
                {
                    
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
    }
}
