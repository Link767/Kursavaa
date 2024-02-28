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

namespace Kursavaa.WinAddFolder
{
    public partial class UserAdd : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter; DataTable dataTable;
        SqlDataReader dataReader; SqlCommand sqlCommand;
        ClassCB classCB;
        Users users;
        public UserAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            users = new Users();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserAdd_loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadGender(cdGender);
            classCB.LoadMonth(cdMonth);
            classCB.LoadYear(cdYear);
        }
    }
}
