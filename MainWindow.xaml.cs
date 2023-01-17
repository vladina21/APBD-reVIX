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
using System.Drawing;
using System.ComponentModel;
//using System.Windows.Forms;

namespace Proiect_revix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            
           
            InitializeComponent();
        }



 
        private void LogIn_MouseEnter(object sender, MouseEventArgs e)
        {

            LogIn.Background = Brushes.Violet;
            this.UpdateLayout();
        }

        private void LogIn_MouseLeave(object sender, MouseEventArgs e)
        {
            LogIn.Background = Brushes.Red;
            this.UpdateLayout();
        }


        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            var context = new RevixEntities();
            string enteredEmail = email.Text;
            string enteredPassword = password.Text;
            var query = (from u in context.Utilizator
                         where u.Email == enteredEmail && u.Parola == enteredPassword
                         select u).ToList();
           


            if (query.Any())
            {
                
                Users.SetUserEmail(email.Text);
                string ID = (from u in context.Utilizator
                         where u.Email == email.Text
                         select u.IDUser).FirstOrDefault().ToString();
                Users.SetUserID(Int32.Parse(ID));
                Meniu mn = new Meniu();
                mn.Show();
                Close();
            }
            else
            {
                var window = new EroareLogare();
                window.Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register rg = new Register();
            rg.Show();
            Close();
        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {
            email.Text = string.Empty;
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == String.Empty)
            {
                email.Text = "Enter your email";
            }
        }

        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            password.Text = string.Empty;
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (password.Text == String.Empty)
            {
                password.Text = "Enter your password";
            }
            
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox nextTextBox = (TextBox)FindName("password");
                if (nextTextBox != null)
                {
                    nextTextBox.Focus();
                }
            }

        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button nextButton = (Button)FindName("LogIn");
                if (nextButton != null)
                {
                    nextButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }
    }
}
