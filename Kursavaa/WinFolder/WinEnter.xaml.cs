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
    public partial class WinEnter : Window {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        public static int IdRole { get; set; }
        public WinEnter() {
            InitializeComponent();      
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrEmpty(tbLogin.Text))
                {
                    Class.ClassMB.InformationMB("Введите логин");
                }
                else if (string.IsNullOrEmpty(pbPassword.Password))
                {
                    Class.ClassMB.InformationMB("Введите пароль");
                }
                else
                {
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand = new SqlCommand("Select Password, IdRole from dbo.[Accountant] " +
                            $"where Login = '{tbLogin.Text}'", sqlConnection);
                        dataReader = sqlCommand.ExecuteReader();
                        dataReader.Read();

                        if (pbPassword.Password != dataReader[0].ToString())
                        {
                            Class.ClassMB.ErrorMB("Неправильный логин или пароль");
                        }
                        else
                        {
                            IdRole = Convert.ToInt32(dataReader[1].ToString());

                            switch (IdRole)
                            {
                                case 1:
                                    new LK().Show();
                                    Close();
                                    break;
                            }
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Class.ClassMB.ErrorMB(ex);
                    }
                }
            }
        }
    }
}
