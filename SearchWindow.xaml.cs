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
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private string comboText;
        private string textBox;
        public SearchWindow(string selectedItem, string introducedText)
        {

            InitializeComponent();
            
            RevixEntities context = new RevixEntities();
            comboText = selectedItem;
            textBox = introducedText;
            if (comboText == "Genres")
            {
                membersDataGrid.ItemsSource = null;

                var filme = from t in context.Toate
                            join f in context.Filme
                            on t.ID equals f.ID
                            where f.Gen.Contains(textBox)
                            select new
                            {
                                ImagePath = t.ImagePath,
                                Titlu = t.Titlu,
                                Descriere = t.Descriere,
                                DataLansarii = t.DataLansarii,
                              
                                Gen = f.Gen,
                            };

                var seriale = from t in context.Toate
                              join s in context.Seriale
                              on t.ID equals s.ID
                              where s.Gen.Contains(textBox)
                              select new
                              {
                                  ImagePath = t.ImagePath,
                                  Titlu = t.Titlu,
                                  Descriere = t.Descriere,
                                  DataLansarii = t.DataLansarii,
                                  Gen = s.Gen

                              };

                var result = filme.ToList();
                var series = seriale.ToList();
                var final = result.Concat(series);
                membersDataGrid.ItemsSource = final;
            }else if (comboText== "Titles")
            {
                membersDataGrid.ItemsSource = null;
                var toate = from t in context.Toate
                            where t.Titlu.Contains(textBox)
                            select new
                            {
                                ImagePath = t.ImagePath,
                                Titlu = t.Titlu,
                                Descriere = t.Descriere,
                                DataLansarii = t.DataLansarii,
                           
                            };

                var result = toate.ToList();
                membersDataGrid.ItemsSource = result;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meniu mn = new Meniu();
            mn.Show();
            Close();
        }
    }
}
