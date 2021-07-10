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
using System.Collections.ObjectModel;

namespace Supermarket_Mangment_System
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Page
    {
        SqlConnection con;
        string id;
        public Invoice(string ID)
        {
            id = ID;
            InitializeComponent();
            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();

            string query = "select * from stock ";

            ItemsTable(query,"Stock");

            query = "truncate table Temp";
            ItemsTable(query, "Temp");
        }


        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = "select * from Stock where Name like '%" + search.Text + "%' or Serial_No like '%"+search.Text +"%'" ;

            ItemsTable(query, "Stock");

        }


        private void AddItem(object sender, RoutedEventArgs e)
        {
            object item = dataGrid.SelectedItem;
            if (dataGrid.SelectedCells.Count > 0)
            {

                int val = Convert.ToInt32((dataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
                string Serial = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;


                if (quantity.Text.Equals(String.Empty))
                {
                    MessageBox.Show("Enter Quantity");
                    return;
                }

                int qty = Convert.ToInt32(quantity.Text);
                if (qty > val || qty < 0)
                {
                    MessageBox.Show("Stock is Out");
                    return;
                }


                string SerialNo = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                string Name = (dataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                int Qty = Convert.ToInt32(quantity.Text);
                int Price = Convert.ToInt32((dataGrid.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text);
                string Discount = (dataGrid.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;


                string query = "insert into Temp values ( '" + SerialNo + "','" + Name + "','" + Qty + "','" + Discount + "','" + Price + "','" + Price * Qty + "')  ";

                try
                {

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException se) {
                    MessageBox.Show(se.Message);
                }

                query = "Select * from Temp";
                ItemsTable(query, "Temp");

                TotalPrice();
            }
            else
                MessageBox.Show("Select Row First!!!");
                quantity.Text = string.Empty;
        }

       
        private void ItemsTable(string query,string table)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                if(table == "Stock")
                {
                    dataGrid.ItemsSource = dt.DefaultView;
                }
                else if (table == "Temp")
                {
                    inGrid.ItemsSource = dt.DefaultView;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Remove_Button(object sender, RoutedEventArgs e)
        {
            object item = inGrid.SelectedItem;
            if (inGrid.SelectedCells.Count > 0)
            {

                string serial = (inGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;


                string query = "Delete from Temp where SerialNo= '" + serial + "'";


                ItemsTable(query, "Temp"); 
                query = "select * from Temp";

                ItemsTable(query, "Temp");

                TotalPrice();
                
            }

            else
                MessageBox.Show("Select Row First!!!");
        }

        private void TotalPrice()
        {
            string query = "Select sum(TotalPrice) from temp";
            DataTable dt = TableReturn(query);
            

            Total.Text = dt.Rows[0][0].ToString();
        }

        private void Checkout_Button(object sender, RoutedEventArgs e)
        {
            
            string query = "select Serial_No, st.Quantity,tm.Quantity from Stock as st join Temp as tm on st.Serial_No = tm.SerialNo";


            DataTable dt = TableReturn(query);

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                int qty = Convert.ToInt32( dt.Rows[i][1].ToString() ) - Convert.ToInt32(dt.Rows[i][2].ToString());
                query = "update Stock set Quantity ='" + qty + "' where Serial_No ='" +dt.Rows[i][0] + "'";
                ItemsTable(query, "Temp");
                i++;
            }

            query = "select * from Temp ";

            dt = TableReturn(query);

            i = 0;
            
            foreach (DataRow row in dt.Rows)
            {
                query = "insert into Invoice (SerialNo,Name,Quantity,Discount,Per_item,TotalPrice,Date,Time) values ('" + dt.Rows[i][0] + "','" + dt.Rows[i][1] + "','" + dt.Rows[i][2] + "','" + dt.Rows[i][3] +"','" + dt.Rows[i][4] +"','"+dt.Rows[i][5] + "',GETDATE() , CAST(GETDATE() as TIME))";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                i++;
            }


            query = "truncate table Temp ";
            ItemsTable(query, "Temp"); ;
            Total.Text = string.Empty;


            query = "select * from stock";
            ItemsTable(query, "Stock");

            MessageBox.Show("Checked Out Sucessfull!!!");
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Salesman uri = new Salesman(id);
            NavigationService.Navigate(uri);
        }

        private DataTable TableReturn (string query) {
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

            return dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string query = "select * from Stock where Name like '%" + search.Text + "%'";

            ItemsTable(query, "Stock");
        }
    }



}
