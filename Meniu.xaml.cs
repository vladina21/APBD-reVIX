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
    /// Interaction logic for Meniu.xaml
    /// </summary>
    public partial class Meniu : Window
    {
        public Meniu()
        {
            InitializeComponent();
            helloLabel.Content = "Hello, " + Users.GetUserEmail() +" !";
        }

        private void Search_GotFocus(object sender, RoutedEventArgs e)
        {
            Search.Text = string.Empty;
        }

        private void Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Search.Text == String.Empty)
            {
                Search.Text = "Looking for...";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Celebs c = new Celebs();
            c.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lista_movies ls = new lista_movies();
            ls.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void Serialebuton_Click(object sender, RoutedEventArgs e)
        {
            lista_seriale ls = new lista_seriale();
            ls.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            lista_tvshow tv = new lista_tvshow();
            tv.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            lista_documentare ld = new lista_documentare();
            ld.Show();
            Close();
        }

        private void Search1_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = searchCombo.Text;
            string introducedText = Search.Text;
  
            SearchWindow s = new SearchWindow(selectedItem, introducedText);
            s.Show();
            Close();
            
        }
    }
}
