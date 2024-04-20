using Kursavaa.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Kursavaa.WinFolder
{   
    public partial class LK : Window
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        Class.ClassDG classDG;
        
        public LK()
        {
            InitializeComponent();
        }

        private void Prod(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Show();
            this.Close();
        }

        private void Zac(object sender, RoutedEventArgs e)
        {
            Zac zac = new Zac();
            zac.Show();
            this.Close();
        }

        private void Kas(object sender, RoutedEventArgs e)
        {
            Kassa kassa = new Kassa();
            kassa.Show();
            this.Close();
        }

        private void Staf(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
            this.Close();
        }

        private void User(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OPo oPo = new OPo();
            oPo.Show();
            this.Close();
        }

        private void DGLK_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            classDG.LoadDB("Select * from ViewAcc");
            dataReader = sqlCommand.ExecuteReader();
            dataReader.Read();
            Login.Text = dataReader["Login"].ToString();;
            Pass.Text = dataReader["Password"].ToString();
            dataReader.Close();
            sqlConnection.Close();
        }
    }
}
