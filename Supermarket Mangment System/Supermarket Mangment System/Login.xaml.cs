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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Supermarket_Mangment_System
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        SqlConnection con;
        string employee;
        public Login(string person)
        {
           
            InitializeComponent();
            employee = person.ToString();
            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!Regex.IsMatch(username.Text, "^[0-9]{1,}$"))
            {
                MessageBox.Show("Invalid Phone Number or Password");
                return;
            }

            if (!username.Text.Equals(String.Empty) || !pass.Password.Equals(String.Empty))
            {
                string query = "Select count(*) from Employee where Phone = '" + username.Text + "' and Password = '" + pass.Password + "'and Title = '" + employee + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();            
                da.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (employee == "Manager")
                    {
                        Uri uri = new Uri("Manager.xaml", UriKind.Relative);
                        NavigationService.Navigate(uri);
                    }
                    else
                    {
                        
                        Salesman sm = new Salesman(username.Text);
                        NavigationService.Navigate(sm); 
                    }

                }
                else
                    MessageBox.Show("Invalid Phone Number or Password");

            }
            else
                MessageBox.Show("Empty Cells!!!");



        }
    }
}
