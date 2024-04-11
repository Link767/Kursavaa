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
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace Kursavaa.WinAddFolder
{
    public partial class UserAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Users users;
        public static string IdUser { get; set;}
        public UserAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            users = new Users();
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[User] " +
                    "(Name, Surname, LastName, Number, IdGender) " +
                    "Values " +
                    "(@Name, @Surname, @LastName, @Number, @IdGender)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("Name", TBName.Text);
                sqlCommand.Parameters.AddWithValue("Surname", TBSurname.Text);
                sqlCommand.Parameters.AddWithValue("LastName", TBLastName.Text);
                sqlCommand.Parameters.AddWithValue("Number", Num.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", cdGender.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Добавление клиента прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                users.Show();
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

        private void UserAdd_loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadGender(cdGender);
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Show();
            Close();
        }
    }
}
