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
            try { 

                // Добавление Zac
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[Zakaz] " +
                    "(IdProdukt, IdUser, IdPoint, IdStatus) " +
                    "Values " +
                    "(@IdProdukt, @IdUser, @IdPoint, @IdStatus)", sqlConnection);

                    sqlCommand.Parameters.AddWithValue("IdUser", cbUserSurname.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("IdProdukt", сdProdName.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("IdPoint", cbPoint.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("IdStatus", cbStatus.SelectedValue.ToString());
            
                    sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Добавление кассы прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                Zac zac = new Zac();
                zac.Show();
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
            classCB.LoadStatus(cbStatus);
            classCB.LoadPoint(cbPoint);
            classCB.LoadProduktName(сdProdName);
            classCB.LoadUserSurname(cbUserSurname);
        }
    }
}
