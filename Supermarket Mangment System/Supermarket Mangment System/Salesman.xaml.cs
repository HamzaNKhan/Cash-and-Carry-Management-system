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



namespace Supermarket_Mangment_System
{
    /// <summary>
    /// Interaction logic for Salesman.xaml
    /// </summary>
    public partial class Salesman : Page
    {
        string ID;
        string ph;
        string inTime;
        string outTime;
        SqlConnection con;
        public Salesman(string saleman)
        {
            ph = saleman;
            InitializeComponent();
            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();
            string query = "select ID from Employee where Phone = '" + saleman + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ID = dt.Rows[0][0].ToString();
            inTime = DateTime.Now.TimeOfDay.ToString();
        }

        public Salesman()
        {
            InitializeComponent();
            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();
        }


        private void See_List(object sender, RoutedEventArgs e)
        {
            string query = "select * from stock ";

            grid(query);

        }


        private void expiredBtn(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.UtcNow.Date;
            string query = "select * from Stock where Expiry_Date <= '" + date + "'";

            grid(query);


        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = "select * from Stock where Name like '%" + search.Text + "%'";

            grid(query);

        }


        private void Logout(object sender, RoutedEventArgs e)
        {
            outTime = DateTime.Now.TimeOfDay.ToString();

            string query = "insert into SMan_IO values ('" + ID+ "',GETDATE(),'" +inTime+"','"+outTime+"')" ;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Uri uri = new Uri("MainWindow.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }


        private void grid(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Invoice(object sender, RoutedEventArgs e)
        {
            Invoice inv = new Invoice(ph);
            NavigationService.Navigate(inv);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            string query = "select * from Stock where Name like '%" + search.Text + "%'";

            grid(query);
        }
    }
}
