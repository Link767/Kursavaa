﻿using Kursavaa.WinAddFolder;
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
    /// Логика взаимодействия для Staff.xaml
    /// </summary>
    public partial class Staff : Window
    {
        Class.ClassDG classDG;
        public Staff()
        {
            InitializeComponent();
            classDG = new Class.ClassDG(DgStaff);
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

        private void DGStaff_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from ViewStaff");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StaffAdd staffAdd = new StaffAdd();
            staffAdd.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) {
            MessageBoxResult result =
                MessageBox.Show("Вы действительно желаете удалить?",
                "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                classDG.DelitRowDB("Delete dbo.[Staff] " +
                $"Where [IdStaff]='{classDG.SelectId()}'");
                classDG.LoadDB("Select * From dbo.[ViewStaff]");
            }
        }
    }
}
