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
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace Supermarket_Mangment_System
{
    /// <summary>
    /// Interaction logic for Add_Stock.xaml
    /// </summary>
    public partial class Add_Stock : Page
    {
        SqlConnection con;
        public Add_Stock()
        {
            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            InitializeComponent();
            con = new SqlConnection(constring);
            con.Open();
        }

        bool Valid = true;
        private void Add(object sender, RoutedEventArgs e)
        {
            invalid.Visibility = Visibility.Hidden;

            if (Regex.IsMatch(qty.Text, "[^0-9]{1,1000}$" ) || Regex.IsMatch(price.Text, "[^0-9]{1,}$") || Regex.IsMatch(discount.Text, "[^0-9]{1,100}$") || qty.Text.Equals(string.Empty) || serial.Text.Equals(string.Empty) || name.Text.Equals(string.Empty) || category.Text.Equals(string.Empty) || price.Text.Equals(string.Empty) || discount.Text.Equals(string.Empty) || expiry.Text.Equals(string.Empty))
            {
                Valid = false;
                invalid.Visibility = Visibility.Visible;

            }


            if (Valid)
            {
                decimal disPrice = Convert.ToDecimal(price.Text) - (Convert.ToDecimal(discount.Text.ToString()) / 100) * Convert.ToDecimal(price.Text);
                string query = "insert into Stock(Serial_No, Name, Category, Quantity, Price, Discount, Discounted_Price, Expiry_Date) "
                              + "Values ('" + serial.Text + "', '" + name.Text + "', '" + category.Text + "', '" + Convert.ToInt32(qty.Text) + "', '" + Convert.ToDecimal(price.Text) + "', '" + discount.Text + "%"+ "', '" +disPrice.ToString() + "', '" + expiry.Text + "' )";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                        
                        Uri uri = new Uri("Manager.xaml", UriKind.Relative);
                        NavigationService.Navigate(uri);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
     
        }
    }
}
