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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
            SqlConnection con;
        public MainWindow()
        {
            InitializeComponent();

            string constring = "Data Source=HAMZA-PC\\SQLEXPRESS;Initial Catalog=Details;Integrated Security=True";
            con = new SqlConnection(constring);
            con.Open();
            
        }

      

        private void Manager(object sender, RoutedEventArgs e)
        {
            
            Login mw = new Login("Manager");
            NavigationService.Navigate(mw);
        }


        private void Salesman(object sender, RoutedEventArgs e)
        {
            
            Login mw = new Login("Salesman");
            NavigationService.Navigate(mw);
        }
    }
}
