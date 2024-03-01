using Kursavaa.Class;
using Kursavaa.WinFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Net;

namespace Kursavaa.WinAddFolder
{
    public partial class ZacAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Zac zac;

        public static string IdProdukt {get; set; }
        public static string IdUser {get; set; }
        public ZacAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            zac = new Zac();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Добавление продукта
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Insert into dbo.[Produkt] " +
                "(ProduktName, Cost) " +
                "Values " +
                "(@ProduktName, @Cost)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("ProduktName", TdProdName.Text);
            sqlCommand.Parameters.AddWithValue("Cost", TdCost.Text);
            sqlCommand.ExecuteNonQuery();

            //получение IdProdukt
            sqlCommand = new SqlCommand("Select IdProdukt from dbo.Produkt " +
               $"where ProduktName = {TdProdName.Text}", sqlConnection);

            sqlCommand = new SqlCommand("Select IdProdukt from dbo.Produkt " +
               $"where Cost = {TdCost.Text}", sqlConnection);

            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            IdProdukt = dataReader[0].ToString();
            dataReader.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Добавление User
            sqlCommand = new SqlCommand("Insert into dbo.[User] " +
                 "(Name, Surname) " +
                 "Values " +
                 "(@Name, @Surname)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("Name", TdUserName.Text);
            sqlCommand.Parameters.AddWithValue("Surname", TdSurname.Text);
            sqlCommand.ExecuteNonQuery();

            //получение IdUser
            sqlCommand = new SqlCommand("Select IdUser from dbo.User " +
               $"where Name = {TdProdName.Text}", sqlConnection);

            sqlCommand = new SqlCommand("Select IdUser from dbo.User " +
               $"where Surname = {TdCost.Text}", sqlConnection);

            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            IdUser = dataReader[0].ToString();
            dataReader.Close();

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Добавление Zac
            sqlCommand = new SqlCommand("Insert into dbo.[Zakaz] " +
                "(IdProdukt, IdUser) " +
                "Values " +
                "(@IdProdukt, @IdUser)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("IdProdukt", IdProdukt.ToString());
            sqlCommand.Parameters.AddWithValue("IdUser", IdUser.ToString());
            sqlCommand.ExecuteNonQuery();

            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadStatus(cbStatus);
            classCB.LoadPoint(cbPoint);
        }
    }
}
