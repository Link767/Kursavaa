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
using System.Data.SqlClient;
using Kursavaa.Class;
using Kursavaa.WinFolder;
using System.Data;

namespace Kursavaa.WinAddFolder
{
    public partial class KassaAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString()); 
        SqlDataAdapter dataAdapter; DataTable dataTable; 
        SqlDataReader dataReader; SqlCommand sqlCommand; 
        ClassCB classCB; 
        Kassa kassa;

        public static string IdAddress { get; set; }
        public KassaAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            kassa = new Kassa();
        }

        private void AddKassa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Добавление адреса
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[Address] " +
                    "(HousNumber, IdStreet) " +
                    "Values " +
                    "(@HousNumber, " +
                "@IdStreet)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("HousNumber", TbHouseNumber.Text);
                sqlCommand.Parameters.AddWithValue("IdStreet", cdStreet.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();

                //получение IdAddress
                sqlCommand = new SqlCommand("Select IdAddress from dbo.Address " +
                   $"where HousNumber = {TbHouseNumber.Text}", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                IdAddress = dataReader[0].ToString();
                dataReader.Close();

                //добавление кассы
                sqlCommand = new SqlCommand("Insert into dbo.[Kassa] " +
                    "(IdAddress, IdStaff) " +
                    "Values " +
                    "(@IdAddress, " +
                "@IdStaff)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("IdAddress", IdAddress.ToString());
                sqlCommand.Parameters.AddWithValue("IdStaff", cdStaff.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Добавление кассы прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Kassa kassa = new Kassa();
                kassa.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadCity(cdCity);
            classCB.LoadStreet(cdStreet);
            classCB.LoadFOI(cdStaff);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Kassa kassa = new Kassa();
            kassa.Show();
            Close();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            AddCity addCity = new AddCity();
            addCity.Show();
        }

        private void AddStreet_click(object sender, RoutedEventArgs e)
        {
            AddStreet addStreet = new AddStreet();
            addStreet.Show();
        }
    }
}
