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
using System.Net;

namespace Kursavaa.WinAddFolder
{
    public partial class UserAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Users users;

        public static string IdYear {get; set;}
        public static string IdBirthday { get; set; }
        public static string IdUser { get; set;}
        public UserAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            users = new Users();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Добавление Года
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Insert into dbo.[Year] " +
                "(YearName,) " +
                "Values " +
                "(@YearName)" , sqlConnection);

            sqlCommand.Parameters.AddWithValue("YearName", TBYear.Text);
            sqlCommand.ExecuteNonQuery();

            //получение Года
            sqlCommand = new SqlCommand("Select IdYear from dbo.Year " +
               $"where YearName = {TBYear.Text}", sqlConnection);
            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            IdYear = dataReader[0].ToString();
            dataReader.Close();


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Добавление Дня

            sqlCommand = new SqlCommand("Insert into dbo.[Birthday] " +
                "(Day, IdMonth) " +
                "Values " +
                "(@Day, " +
            "@IdMonth)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("Day", Day.Text);
            sqlCommand.Parameters.AddWithValue("IdMonth", cdMonth.SelectedValue.ToString());
            sqlCommand.ExecuteNonQuery();

            //получение Дня
            sqlCommand = new SqlCommand("Select IdBirthday from dbo.Birthday " +
               $"where Day = {Day.Text}", sqlConnection);
            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            IdBirthday = dataReader[0].ToString();
            dataReader.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            // Добавление User
            sqlCommand = new SqlCommand("Insert into dbo.[User] " +
                "(Name, Surname, LastName, Number, IdGender, IdBirthday) " +
                "Values " +
                "(@Name, @Surname, @LastName, @Number, @IdGender, @IdBirthday)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("Name", TBName.Text);
            sqlCommand.Parameters.AddWithValue("Surname", TBSurname.Text);
            sqlCommand.Parameters.AddWithValue("LastName", TBLastName.Text);
            sqlCommand.Parameters.AddWithValue("Number", Num.Text);
            sqlCommand.Parameters.AddWithValue("IdGender", cdGender.SelectedValue.ToString());
            sqlCommand.Parameters.AddWithValue("IdBirthday", cdMonth.SelectedValue.ToString());
            sqlCommand.ExecuteNonQuery();

            //получение User
            sqlCommand = new SqlCommand("Select IdUser from dbo.User " +
               $"where Name = {TBName.Text}", sqlConnection);

            sqlCommand = new SqlCommand("Select IdUser from dbo.User " +
               $"where Surname = {TBSurname.Text}", sqlConnection);

            sqlCommand = new SqlCommand("Select IdUser from dbo.User " +
               $"where LastName = {TBLastName.Text}", sqlConnection);

            sqlCommand = new SqlCommand("Select IdUser from dbo.User " +
               $"where Number = {Num.Text}", sqlConnection);
            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            IdUser = dataReader[0].ToString();
            dataReader.Close();

        }

        private void UserAdd_loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadGender(cdGender);
            classCB.LoadMonth(cdMonth);
        }
    }
}
