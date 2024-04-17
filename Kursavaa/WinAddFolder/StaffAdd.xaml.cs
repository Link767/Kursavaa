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
using System.Xml.Linq;

namespace Kursavaa.WinAddFolder
{
    public partial class StaffAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        SqlDataReader dataReader; 
        SqlCommand sqlCommand;
        ClassCB classCB;
        Staff staff;

        public StaffAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            staff = new Staff();
        }

        private void AddKassa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[Staff] " +
                    "(Name, Surname, LastName, IdGender, IdMaritalStatus) " +
                    "Values " +
                    "(@Name, @Surname, @LastName, @IdGender, @IdMaritalStatus)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("Name", Name.Text);
                sqlCommand.Parameters.AddWithValue("Surname", TBSurname.Text);
                sqlCommand.Parameters.AddWithValue("LastName", TBLastName.Text);
                sqlCommand.Parameters.AddWithValue("IdGender", cdGender.SelectedValue.ToString());
                sqlCommand.Parameters.AddWithValue("IdMaritalStatus", cdMaritalStatus.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Добавление клиента прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                staff.Show();
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
            classCB.LoadGender(cdGender);
            classCB.LoadMaritalStatus(cdMaritalStatus);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            Close();
        }
    }
}
