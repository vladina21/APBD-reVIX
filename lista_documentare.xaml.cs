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
    /// Interaction logic for lista_documentare.xaml
    /// </summary>
    public partial class lista_documentare : Window
    {

        public class Documentar
        {
            public int Id { get; set; }
            public string ImagePath { get; set; }
            public string Titlu { get; set; }
            public string Descriere { get; set; }
            public DateTime DataLansarii { get; set; }
            public string Prezentator { get; set; }
        }
        public lista_documentare()
        {
            InitializeComponent();
            Curent.SetWindow("Documentare");
            membersDataGrid.ItemsSource = null;
            var context = new RevixEntities();

            var documentare = from t in context.Toate
                              join d in context.Documentare
                              on t.ID equals d.ID
                       select new Documentar
                       {
                           Id=t.ID,
                           ImagePath = t.ImagePath,
                           Titlu = t.Titlu,
                           Descriere = t.Descriere,
                           DataLansarii = t.DataLansarii,
                           Prezentator = d.Prezentator,



                       };
            var result = documentare.ToList();
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
            Documentar documentar = b.DataContext as Documentar;

            Recenziexaml mn = new Recenziexaml(documentar.Id);
            mn.Show();
            Close();

        }




    }
}
