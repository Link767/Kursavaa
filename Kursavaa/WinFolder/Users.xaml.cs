using Kursavaa.WinAddFolder;
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

namespace Kursavaa.WinFolder
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        Class.ClassDG classDG;
        public Users()
        {
            InitializeComponent();
            classDG = new Class.ClassDG(DgUser);
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

        private void lklk(object sender, RoutedEventArgs e)
        {
            LK lK = new LK();
            lK.Show();
            this.Close();
        }

        private void DGUser_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from ViewUser");
        }

        private void UserAdd_Click(object sender, RoutedEventArgs e)
        {
            UserAdd userAdd = new UserAdd();
            userAdd.Show();
            this.Close();
        }
    }
}
