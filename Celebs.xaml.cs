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
    /// Interaction logic for Celebs.xaml
    /// </summary>
    public partial class Celebs : Window
    {
        public class Actori
        {
            public int Id { get; set; }
            public string ImagePath { get; set; }
            public string NumeComplet { get; set; }
            public string Varsta { get; set; }
            public string DistributedIN { get; set; }
        }
        public Celebs()
        {
            InitializeComponent();

            membersDataGrid.ItemsSource = null;
            var context = new RevixEntities();
            var actori = from a in context.Actori
                         select new Actori
                         {
                             Id = a.IDActor,
                             ImagePath = a.ImagePath,
                             NumeComplet=a.Prenume +" "+ a.Nume,
                             Varsta = a.Varsta,
                             DistributedIN=a.DistributedIn


                         };

            var result = actori.ToList();
            membersDataGrid.ItemsSource = result;
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var m2 = new Meniu();
            m2.Show();
            Close();

        }
    }
}
