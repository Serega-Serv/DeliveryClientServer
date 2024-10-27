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
using System.Security.Cryptography;

using System.Data;
using System.Data.SqlClient;


namespace Delivery {
    public partial class MainWindow : Window {
        public string connectionString;
        private SqlConnection connection;
        String district, firstDate;
        string pattern = @"^(19|20)\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01]) (0[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9](\.\d{1,3})?)$";
        public MainWindow() {
            InitializeComponent();

        }

        private void sqlRequest() {

            district = District.Text;
            district = district.Replace("'", "['']");
            district = district.Replace("%", "[%]");

            firstDate = FirstDate.Text;

            if (Regex.IsMatch(firstDate, pattern)) {


                try {
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
        }

        private void FirstDate_GotFocus(object sender, RoutedEventArgs e) {
            if (FirstDate.Text == "yyyy-mm-dd hh:mm:ss.sss") {
                FirstDate.Text = string.Empty;
                FirstDate.Foreground = System.Windows.Media.Brushes.Black;
            } else if (FirstDate.Text == string.Empty) {
                FirstDate.Text = "yyyy-mm-dd hh:mm:ss.sss";
                FirstDate.Foreground = System.Windows.Media.Brushes.Gray;
            } 
        }

        private void District_GotFocus(object sender, RoutedEventArgs e) {
            if (District.Text == "Район") {
                District.Text = string.Empty;
                District.Foreground = System.Windows.Media.Brushes.Black;
            } else if (District.Text == string.Empty) {
                District.Text = "Район";
                District.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void Server_GotFocus(object sender, RoutedEventArgs e) {
            if (Server.Text == "Имя Сервера") {
                Server.Text = string.Empty;
                Server.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            try {
                connection = new SqlConnection(@"Data Source = " + Server.Text + ";;Initial Catalog = tost_1;" + "Integrated Security = True; Connect Timeout = 15; Encrypt=False;" + "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();

                if (connection != null) {
                    sqlRequest();
                    MessageBox.Show(connection.ToString());
                }
            }
            catch (SqlException error) {
                MessageBox.Show(error.Message);
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (connection != null) {
                connection.Close();
            }
        }
    }
}
