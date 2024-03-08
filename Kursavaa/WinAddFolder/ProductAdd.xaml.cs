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
    public partial class ProductAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Product product;

        public static string IdProdukt { get; set; }
        public ProductAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            product = new Product();
        }

        private void AddKassa_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 

                // Добавление Года
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[Produkt] " +
                "(ProduktName, Cost) " +
                "Values " +
                "(@ProduktName, @Cost)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("ProduktName", TBProName.Text);
                sqlCommand.Parameters.AddWithValue("Cost", TBCost.Text);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                //получение Года
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select IdProdukt from dbo.Produkt " +
               $"where ProduktName = {TBProName.Text}", sqlConnection);
                sqlConnection.Close();


                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select IdProdukt from dbo.Produkt " +
               $"where Cost = {TBCost.Text}", sqlConnection);
            

                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                IdProdukt = dataReader[0].ToString();
                dataReader.Close();

            

                MessageBox.Show("Добавление кассы прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                Product product = new Product();
                product.Show();
                this.Close();

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
           
        }
    }
}
