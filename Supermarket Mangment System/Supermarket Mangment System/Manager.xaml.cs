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
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Page
    {
        SqlConnection con;
        public Manager()
        {
            InitializeComponent();

            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();
        }

        private void See_List(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;

            string query = "select * from stock ";

            grid(query);


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;

            Uri uri = new Uri("Add_Stock.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void expiredBtn(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;
            DateTime date = DateTime.UtcNow.Date;
            string query = "select * from Stock where Expiry_Date <= '" + date + "'";

            grid(query);


        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;

            string query = "select * from Stock where Name like '%" + search.Text + "%'";

            grid(query);

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;

            object item = datagrid.SelectedItem;
            if(datagrid.SelectedCells.Count>0)
            {

                string serial = (datagrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
          

                string query = "Delete from Stock where Serial_No= '" +serial+ "'";


                grid(query);
                query = "select * from stock ";

                grid(query);

                MessageBox.Show("Record Updated");
            }

            else
                MessageBox.Show("Select Row First!!!");


        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;

            if (datagrid.SelectedCells.Count > 0)
            {
                object item = datagrid.SelectedItem;
                string serial = (datagrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string name = (datagrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                string category = (datagrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                string qnty = (datagrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                string price = (datagrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                string dscnt = (datagrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                string expiryDate = (datagrid.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
                dscnt = Regex.Replace(dscnt, "[%]", string.Empty);

                decimal disPrice = Convert.ToDecimal(price.ToString()) - (Convert.ToDecimal(dscnt.ToString()) / 100) * Convert.ToDecimal(price.ToString());

                string query = "update Stock set  Name ='" + name + "', Category = '" + category + "', Quantity = '" + qnty + "', Price = '" + price + "', Discount = '" + dscnt +"%" +"', Discounted_Price= '" + disPrice + "',Expiry_Date ='" + expiryDate + "' where Serial_No = '" +  serial+ "'";
                grid(query);


                query = "select * from stock where Serial_No = '" + serial +"'";

                grid(query);

                MessageBox.Show("Record Updated");
            }

            else
                MessageBox.Show("Select Row First!!!");


        }

        private void Logout(object sender, RoutedEventArgs e)
        {
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
                datagrid.IsReadOnly = false;
                update.Visibility = Visibility.Visible;
                add.Visibility = Visibility.Visible;
                remove.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Salesman_Profile(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedCells.Count > 0)
            {
                object item = datagrid.SelectedItem;
                string id = (datagrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                SalesmanProfile pro = new SalesmanProfile(id);
                NavigationService.Navigate(pro);
            }
        }
        private void SeeSMList(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Visible;

            string query = "Select * from Employee where Title ='Salesman'";
            grid(query);

            datagrid.IsReadOnly = true;
            update.Visibility = Visibility.Hidden;
            add.Visibility = Visibility.Hidden;
            remove.Visibility = Visibility.Hidden;
        }

        private void Sold(object sender, RoutedEventArgs e)
        {
            string query = "Select * from Invoice ";
            grid(query);
            datagrid.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            profile.Visibility = Visibility.Hidden;

            string query = "select * from Stock where Name like '%" + search.Text + "%'";

            grid(query);
        }
    }
}
