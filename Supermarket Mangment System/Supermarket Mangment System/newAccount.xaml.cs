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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Supermarket_Mangment_System
{
    /// <summary>
    /// Interaction logic for newAccount.xaml
    /// </summary>
    public partial class newAccount : Page
    {
        SqlConnection con;
        public newAccount()
        {
            InitializeComponent();
            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool valid = true;

            if (Regex.IsMatch(FName.Text, "[^a-zA-Z]$") || FName.Text.Equals(String.Empty))
            {
                valid = false;
                FirstRequried.Visibility = Visibility.Visible;
                FName.Text = String.Empty;
            }
            else
                FirstRequried.Visibility = Visibility.Hidden;

            if (Regex.IsMatch(LName.Text, "[^a-zA-Z]") || LName.Text.Equals(String.Empty))
            {
                valid = false;
                LastRequired.Visibility = Visibility.Visible;
                LName.Text = String.Empty;
            }
            else
                LastRequired.Visibility = Visibility.Hidden;

            if (Email.Text.Equals(String.Empty) || !IsValidEmail(Email.Text))
            {
                valid = false;
                EmailRequired.Visibility = Visibility.Visible;
                Email.Text = String.Empty;
            }
            else
                EmailRequired.Visibility = Visibility.Hidden;


            if (pass.Password.Equals(String.Empty) || !ISValidPassword(pass.Password))
            {
                valid = false;
                PasswordRequired.Visibility = Visibility.Visible;
                pass.Password = String.Empty;
            }
            else
                PasswordRequired.Visibility = Visibility.Hidden;

            if (number.Text.Equals(string.Empty) || !IsValidNumber(number.Text))
            {
                valid = false;
                NumberRequired.Visibility = Visibility.Visible;
                number.Text = String.Empty;
            }
            else
                NumberRequired.Visibility = Visibility.Hidden;
            if (DOB.Text.Equals(String.Empty))
            {
                valid = false;
                DOBRequired.Visibility = Visibility.Visible;
            }
            else
                DOBRequired.Visibility = Visibility.Hidden;


            if(!Regex.IsMatch(pass.Password, repass.Password) ||repass.Password.Equals(String.Empty))
            {
                valid = false;
                matchRequried.Visibility = Visibility.Visible;

            }

            else
                matchRequried.Visibility = Visibility.Hidden;

            string Gender;
            if (Male.IsChecked == true)
            {
                Gender = "Male";
            }
            else
                Gender = "Female";

            if (valid)
            {
                string FirstName = FName.Text, LastName = LName.Text, email = Email.Text, Password = pass.Password, Phone = number.Text, DateofBirth = DOB.Text;
                string query,Title;

                var item = (ComboBoxItem)Combo.SelectedValue;
                var content = (string)item.Content;


                if (content.Equals("Manager"))
                {
                    Title = "Manager";
                }
                else
                {

                    Title = "Salesman";
                }

                query = "insert into Employee(FirstName, LastName, Email, Password, Phone, DateofBirth, Gender,Title) "
                               + "Values ('" + FirstName + "', '" + LastName + "', '" + email + "', '" + Password + "', '" + Phone + "', '" + DateofBirth + "', '" + Gender + "' , '" + Title + "' )";


                try
                {
                    using(SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account Created");
                        Uri uri = new Uri("MainWindow.xaml", UriKind.Relative);
                        NavigationService.Navigate(uri);
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }



        private bool IsValidEmail(string Email)
        {
            try
            {
                MailAddress m = new MailAddress(Email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool ISValidPassword(string password)
        {
            if (Regex.IsMatch(password, "^(?=.*?[A-Z]).{8,}$"))
            {
                return true;
            }
            else
                return false;
        }

        private bool IsValidNumber(string number)
        {
            if (Regex.IsMatch(number, "^[0-9]{11}$"))
            {
                return true;
            }
            else
                return false;

        }
       
    }
}
