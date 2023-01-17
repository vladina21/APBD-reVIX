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
    /// Interaction logic for EroareAdaugareUtilizator.xaml
    /// </summary>
    public partial class EroareAdaugareUtilizator : Window
    {
        Register regPage;
        public EroareAdaugareUtilizator( Register r)
        {
            InitializeComponent();
            regPage= r ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
            regPage.Close();
        }
    }
}
