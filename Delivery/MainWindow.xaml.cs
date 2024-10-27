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


using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

using System.Data;
using System.Data.SqlClient;

namespace Delivery {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public const string connectionString = @"Data Source = DESKTOP-52L8N5J\SQLEXPRESS02;;Initial Catalog = tost_1;" + "Integrated Security = True; Connect Timeout = 15; Encrypt=False;" + "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection;
        String district, firstDate;

        public MainWindow() {
            InitializeComponent();


            try {
                connection = new SqlConnection(connectionString);
                connection.Open();

                sqlRequest();


            }
            catch (SqlException error) {
                MessageBox.Show(error.Message);
            }
        }

        private void sqlRequest() {

            try {
                firstDate = FirstDate.Text;
            firstDate = firstDate.Replace("'", "['']");
            firstDate = firstDate.Replace("%", "[%]");
            district = District.Text;
            district = district.Replace("'", "['']");
            district = district.Replace("%", "[%]");

            string sqlExpression = "SELECT * FROM Orders where district = @district_value AND firstDate >= @firstDate_value";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter district_param = new SqlParameter("@district_value", district); command.Parameters.Add(district_param);
            SqlParameter firstDate_param = new SqlParameter("@firstDate_value", firstDate); command.Parameters.Add(firstDate_param);

            command.ExecuteNonQuery();
            SqlDataAdapter Sql_Data_Adapter = new SqlDataAdapter(command);
            DataTable Data_Table = new DataTable("orders");
            Sql_Data_Adapter.Fill(Data_Table);
            MainGrid.ItemsSource = Data_Table.DefaultView;

            }
            catch (SqlException error) {
                MessageBox.Show(error.Message);
            }
        }

        private void FirstDate_GotFocus(object sender, RoutedEventArgs e) {
            if (FirstDate.Text == "Введите дату первой доставки") {
                FirstDate.Text = string.Empty;
                FirstDate.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void District_GotFocus(object sender, RoutedEventArgs e) {
            if (District.Text == "Введите Район") {
                District.Text = string.Empty;
                District.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void FirstDate_TextChanged(object sender, KeyEventArgs e) {
            if ((connection != null) && (e.Key ==Key.Enter)) sqlRequest();
        }

        private void District_TextChanged(object sender, KeyEventArgs e) {
            if ((connection != null) && (e.Key == Key.Enter)) sqlRequest();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (connection != null) {
                connection.Close();
            }
        }
    }
}
