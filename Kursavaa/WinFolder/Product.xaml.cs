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
    public partial class Product : Window
    {
        Class.ClassDG classDG;
        public Product()
        {
            InitializeComponent();
            classDG = new Class.ClassDG(DgProduct);
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

        private void Kas(object sender, RoutedEventArgs e)
        {
            Kassa kassa = new Kassa();
            kassa.Show();
            this.Close();
        }

        private void lklk(object sender, RoutedEventArgs e)
        {
            LK lK = new LK();
            lK.Show();
            this.Close();
        }

        private void DGPoint_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from ViewProd");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductAdd productAdd = new ProductAdd();
            productAdd.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) { 
                MessageBoxResult result = MessageBox.Show("Вы действительно желаете удалить?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes) {
                    classDG.DelitRowDB("Delete dbo.[Produkt] " +
                    $"Where [IdProdukt]='{classDG.SelectId()}'");
                    classDG.LoadDB("Select * From dbo.[ViewProd]");
                }
        }
    }
}
