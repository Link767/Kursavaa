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

    public partial class AddCity : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Kassa kassa;
        public static string IdContry { get; set; }
        public AddCity()
        {
            InitializeComponent();
            classCB = new ClassCB();
            kassa = new Kassa();
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //добавление города
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[Gity] " +
                    "(GityName, IdContry) " +
                    "Values " +
                    "(@GityName, @IdContry)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("GityName", tbCity.Text);
                sqlCommand.Parameters.AddWithValue("IdContry", cdConty.SelectedValue.ToString());
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
            classCB.LoadContry(cdConty);
        }
    }
}
