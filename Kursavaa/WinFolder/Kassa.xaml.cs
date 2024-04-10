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
using Kursavaa.WinAddFolder;
using Kursavaa.WinDell;

namespace Kursavaa.WinFolder
{
    public partial class Kassa : Window
    {
        Class.ClassDG classDG;
        public Kassa()
        {
            InitializeComponent();
            classDG = new Class.ClassDG(DgKassa);
        }

        private void lk(object sender, RoutedEventArgs e)
        {
            LK lK = new LK();
            lK.Show();
            this.Close();
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

        private void lklk(object sender, RoutedEventArgs e)
        {
            LK lK = new LK();
            lK.Show();
            this.Close();
        }

        private void DGKassa_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from ViewKassa");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KassaAdd kassaAdd = new KassaAdd();
            kassaAdd.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            {
                MessageBoxResult result =
                MessageBox.Show("Вы действительно желаете удалить?",
                "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    classDG.DelitRowDB("Delete dbo.[Kassa] " +
                    $"Where [IdKassa]='{classDG.SelectId()}'");
                    classDG.LoadDB("Select * From dbo.[ViewKassa]");
                }
            }
        }
    }
}
