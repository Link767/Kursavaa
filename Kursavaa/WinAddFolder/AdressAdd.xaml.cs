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
    public partial class AdressAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        KassaAdd kassaAdd;
        public static string IdAddress { get; set; }
        public static string IdStreet { get; set; }
        public static string IdGity { get; set; }
        public AdressAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            kassaAdd = new KassaAdd();
        }

        private void AddAdress_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KassaAdd kassaAdd = new KassaAdd();
            kassaAdd.Show();
            Close();
        }
    }
}
