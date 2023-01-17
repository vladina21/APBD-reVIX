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
    /// Interaction logic for lista_tvshow.xaml
    /// </summary>
    public partial class lista_tvshow : Window
    {
        public class TvShow
        {
            public int Id { get; set; }
            public string ImagePath { get; set; }
            public string Titlu { get; set; }
            public string Descriere { get; set; }
            public DateTime DataLansarii { get; set; }
           
            public string Prezentator { get; set; }
        }

        public lista_tvshow()
        {
            InitializeComponent();
            Curent.SetWindow("Tvshows");
            membersDataGrid.ItemsSource = null;
            var context = new RevixEntities();

            var show = from t in context.Toate
                          join s in context.TvShows
                          on t.ID equals s.ID
                          select new TvShow
                          {
                              Id=t.ID,
                              ImagePath = t.ImagePath,
                              Titlu = t.Titlu,
                              Descriere = t.Descriere,
                              DataLansarii = t.DataLansarii,
                              Prezentator = s.Prezentator,



                          };
            var result = show.ToList();
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
            TvShow tvshow = b.DataContext as TvShow;

            Recenziexaml mn = new Recenziexaml(tvshow.Id);
            mn.Show();
            Close();

        }


    }
}
