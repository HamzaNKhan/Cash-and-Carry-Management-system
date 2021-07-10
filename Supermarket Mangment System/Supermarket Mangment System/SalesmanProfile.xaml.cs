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
    /// Interaction logic for SalesmanProfile.xaml
    /// </summary>
    public partial class SalesmanProfile : Page
    {
        DataTable table;
        SqlConnection con;
        public SalesmanProfile(string id)
        {
            InitializeComponent();
            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();

            string query = "select Date,Chkin as Check_IN,Out as Check_Out from SMan_IO where Id = '" +id+ "'";
            grid(query);

            query = "select * from Employee where ID = '" +id+ "'";
            table = tableReturn(query);
            populate();
        }


        private DataTable tableReturn(string query)
        {
                DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                return dt;

        }

        private void grid(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void populate()
        {
            ID.Text = table.Rows[0][0].ToString();
            FName.Text = table.Rows[0][1].ToString();
            LName.Text = table.Rows[0][2].ToString();
            Email.Text = table.Rows[0][3].ToString();
            number.Text = table.Rows[0][5].ToString();
            gender.Text = table.Rows[0][7].ToString();
            DOB.Text = table.Rows[0][6].ToString();

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Manager.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }
    }
}
