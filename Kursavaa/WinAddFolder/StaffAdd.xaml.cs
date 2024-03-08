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
    public partial class StaffAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Staff staff;

        public static string IdCity {  get; set; }
        public static string IdStreet { get; set; }
        public StaffAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            staff = new Staff();
        }

        private void AddKassa_Click(object sender, RoutedEventArgs e)
        {
            // Добавление Города
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Insert into dbo.[Gity] " +
                "(GityName, IdContry) " +
                "Values " +
                "(@GityName, " +
            "@IdContry)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("GityName", TBCity.Text);
            sqlCommand.Parameters.AddWithValue("IdContry", cbContry.SelectedValue.ToString());
            sqlCommand.ExecuteNonQuery();

            //получение Города
            sqlCommand = new SqlCommand("Select IdGity from dbo.Gity " +
               $"where GityName = {TBCity.Text}", sqlConnection);

            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            IdCity = dataReader[0].ToString();
            dataReader.Close();
            
            sqlConnection.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Добавление улицы
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Insert into dbo.[Street] " +
                "(StreetName, IdGity) " +
                "Values " +
                "(@StreetName, " +
            "@IdGity)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("StreetName", TBStreet.Text);
            sqlCommand.ExecuteNonQuery();

            //получение улицы
            sqlCommand = new SqlCommand("Select IdStreet from dbo.Street " +
               $"where StreetName = {TBStreet.Text}", sqlConnection);

            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            IdStreet = dataReader[0].ToString();
            dataReader.Close();

            sqlConnection.Close();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadGender(cbGender);
            classCB.LoadMaritalStatus(cdMaritalStatus);
            classCB.LoadContry(cbContry);
        }
    }
}
