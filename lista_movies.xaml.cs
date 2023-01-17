using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for lista_movies.xaml
    /// </summary>
    public partial class lista_movies : Window
    {
        
        public class Film
        {
            public int Id { get; set; }
            public string ImagePath { get; set; }
            public string Titlu { get; set; }
            public string Descriere { get; set; }
            public DateTime DataLansarii { get; set; }
            public string Durata { get; set; }
            public string Gen { get; set; }
        }

        
        public lista_movies()
        {
            InitializeComponent();
            Curent.SetWindow("Filme");
            
            membersDataGrid.ItemsSource = null;
            var context = new RevixEntities();
            var filme = from t in context.Toate
                        join f in context.Filme
                        on t.ID equals f.ID
                        select new Film
                        {
                            Id = t.ID,
                            ImagePath = t.ImagePath,
                            Titlu = t.Titlu,
                            Descriere = t.Descriere,
                            DataLansarii = t.DataLansarii,
                            Durata = f.Durata + " min",
                            Gen = f.Gen,
                        };

            var result = filme.ToList();
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
            Film film = b.DataContext as Film;

            Recenziexaml mn = new Recenziexaml(film.Id);
            mn.Show();
            Close();
        }

      
    }
}
