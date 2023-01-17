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
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void firstname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Firstname.Text = "";
        }

        private void lastname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Lastname.Text = "";
        }

        private void email_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Email.Text = "";
        }

        private void password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Password.Text = "";
        }

        private void confirmpassword_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Confirmpassword.Text = "";
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            var context = new RevixEntities();
            

            if (Check.IsChecked == false)
            {
                EroareTermeniSiConditii termsicond = new EroareTermeniSiConditii();
                termsicond.Show();
            }
            else if(Password.Text!=Confirmpassword.Text)
            {
                EroareParole eroareParole= new EroareParole();
                eroareParole.Show();
            }else if(Firstname.Text=="First Name" || Lastname.Text == "Last Name" || Email.Text == "Enter your email")
            {
                var eroareNimic = new EroareNimic();
                eroareNimic.Show();

            }

            else
            {
        

                var utilizatoriExistenti = from u in context.Utilizator
                                           where u.Email == Email.Text
                                           select u;
                if (utilizatoriExistenti.Any())
                {
                    var eroare = new EroareAdaugareUtilizator(this);
                    eroare.Show();

                }else
                {
                    var utilizatorNou = new Utilizator()
                    {
                        Prenume = Firstname.Text,
                        Nume = Lastname.Text,
                        Email = Email.Text,
                        Parola = Password.Text


                    };
                    context.Utilizator.Add(utilizatorNou);
                   // context.SaveChanges();

                    var mn = new Meniu();
                    mn.Show();
                    Close();

                    var succes = new SuccesAdaugareUtilizator();
                    succes.Show();

                }
            


         
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                MainWindow main = new MainWindow();
                main.Show();
                Close();
        }

        private void Firstname_GotFocus(object sender, RoutedEventArgs e)
        {
            Firstname.Text = String.Empty;
        }

        private void Firstname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Firstname.Text == String.Empty)
            {
                Firstname.Text = "Firstname";
            }
        }

        private void Lastname_GotFocus(object sender, RoutedEventArgs e)
        {
            Lastname.Text= String.Empty;
        }

        private void Lastname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Lastname.Text == String.Empty)
            {
                Lastname.Text = "Lastname";
            }
        }

        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            Email.Text= String.Empty;
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Email.Text == String.Empty)
            {
                Email.Text = "Enter your email";
            }
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            Password.Text= String.Empty;
        }

        private void Confirmpassword_LostFocus(object sender, RoutedEventArgs e)
        {

            if (Confirmpassword.Text == String.Empty)
            {
                Confirmpassword.Text = "Confirm your password";
            }
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == String.Empty)
            {
                Password.Text = "Enter your password";
            }
        }

        private void Confirmpassword_GotFocus(object sender, RoutedEventArgs e)
        {
            Confirmpassword.Text= String.Empty; 
        }

        private void Firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox nextTextBox = (TextBox)FindName("Lastname");
                if (nextTextBox != null)
                {
                    nextTextBox.Focus();
                }
            }

        }

        private void Lastname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox nextTextBox = (TextBox)FindName("Email");
                if (nextTextBox != null)
                {
                    nextTextBox.Focus();
                }
            }


        }

        private void Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox nextTextBox = (TextBox)FindName("Password");
                if (nextTextBox != null)
                {
                    nextTextBox.Focus();
                }
            }

        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox nextTextBox = (TextBox)FindName("Confirmpassword");
                if (nextTextBox != null)
                {
                    nextTextBox.Focus();
                }
            }

        }

        private void Confirmpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button nextButton = (Button)FindName("SignIn");
                if (nextButton != null)
                {
                    nextButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }


        }

        private void Check_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button nextButton = (Button)FindName("SignIn");
                if (nextButton != null)
                {
                    nextButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }

        }

       
    }
}
