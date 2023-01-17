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
using System.Windows.Shapes;

namespace Proiect_revix
{
    /// <summary>
    /// Interaction logic for lista_seriale.xaml
    /// </summary>
    public partial class lista_seriale : Window
    {
        public class Serial
        {
            public int Id { get; set; }
            public string ImagePath { get; set; }
            public string Titlu { get; set; }
            public string Descriere { get; set; }
            public DateTime DataLansarii { get; set; }
            public int? Nr_sezoane { get; set; }
            public string Gen { get; set; }

        }

        
        public lista_seriale()
        {
            InitializeComponent();
            Curent.SetWindow("Seriale");
            membersDataGrid.ItemsSource = null;
            var context = new RevixEntities();
           
            var seriale = from t in context.Toate
                        join s in context.Seriale
                        on t.ID equals s.ID
                        select new Serial
                        {
                            Id=t.ID,
                            ImagePath = t.ImagePath,
                            Titlu = t.Titlu,
                            Descriere = t.Descriere,
                            DataLansarii = t.DataLansarii,
                            Nr_sezoane =s.Nr_sezoane,
                            Gen = s.Gen,



                        };
            var result = seriale.ToList();
            membersDataGrid.ItemsSource = result;


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meniu mn = new Meniu();
            mn.Show();
            Close();
        }
        private void recenzie(object sender, RoutedEventArgs e)
        {
           
                Button b = sender as Button;
                Serial serial = b.DataContext as Serial;

                Recenziexaml mn = new Recenziexaml(serial.Id);
                mn.Show();
                Close();
            
        }



    }
}