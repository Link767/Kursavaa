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

namespace Kursavaa.WinAddFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStreet.xaml
    /// </summary>
    public partial class AddStreet : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Kassa kassa;
        public static string IdSreet { get; set; }
        public AddStreet()
        {
            InitializeComponent();
            classCB = new ClassCB();
            kassa = new Kassa();
        }

        private void AddStreet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //добавление города
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[Street] " +
                    "(StreetName, IdGity) " +
                    "Values " +
                    "(@StreetName, @IdGity)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("StreetName", tbStreet.Text);
                sqlCommand.Parameters.AddWithValue("IdGity", cdCity.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Добавление города прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
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
        }
    }
}
