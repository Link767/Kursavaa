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
    /// Логика взаимодействия для ZacAdd.xaml
    /// </summary>
    public partial class ZacAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Zac zac;
        public ZacAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            zac = new Zac();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadStatus(cbStatus);
            classCB.LoadPoint(cbPoint);
        }
    }
}
