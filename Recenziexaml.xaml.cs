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
    /// Interaction logic for Recenziexaml.xaml
    /// </summary>
    public partial class Recenziexaml : Window
    {
        public int Id_film_clicked { get; set; }
        public Recenziexaml(int id)
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = null;
            Id_film_clicked = id;
            var context = new RevixEntities();
            var recenzii = from u in context.Utilizator         
                           join r in context.Recenzii on u.IDUser equals r.IDUser
                           join t in context.Toate on r.ID equals t.ID
                           where t.ID==Id_film_clicked
                           select new
                           {
                               
                               User=u.Email,
                               Review=r.Descriere,
                               ReviewScore=r.Scor,
                               DataPublicarii=r.DataPublicarii


                           };
            
            var result = recenzii.ToList();
            membersDataGrid.ItemsSource = result;





        }
        public class Membru
        {
            public string Nr { get; set; }
            public string Username { get; set; }
            public string Text { get; set; }
            public string Nota { get; set; }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Curent.GetWindow() == "Filme")
            {
                lista_movies lm = new lista_movies();
                lm.Show();
                Close();

            }
            else if (Curent.GetWindow() == "Seriale")
            {
                lista_seriale ls = new lista_seriale();
                ls.Show();
                Close();

            }
            else if (Curent.GetWindow() == "Tvshows")
            {
                lista_tvshow lt = new lista_tvshow();
                lt.Show();
                Close();

            }
            else if (Curent.GetWindow() == "Documentare")
            {
                lista_documentare ld = new lista_documentare();
                ld.Show();
                Close();

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var context = new RevixEntities();
            var comboBoxItem = ScoreComboBox.SelectedItem as ComboBoxItem;
            string str = comboBoxItem.Content.ToString();
            var RecenzieNoua = new Recenzii()
            {
                IDUser = Users.GetUserID(),
                ID = Id_film_clicked,
                DataPublicarii = DateTime.Now,
                Descriere = __TEXT.Text,
                Scor = Convert.ToInt32(str)
            };
            context.Recenzii.Add(RecenzieNoua);
            context.SaveChanges();

           


        }
    }
}