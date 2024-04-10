﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Data.SqlClient;

namespace Kursavaa.Class
{
    class ClassDG
    {
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        DataGrid dataGrid;
        DataTable dataTable;
        SqlCommand SqlCommand;

        public ClassDG(DataGrid dataGrid) {
            this.dataGrid = dataGrid;
        }

        public void LoadDB(string sqlCommand) {
            try {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(sqlCommand, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally {
                sqlConnection.Close();
            }
        }

        public string SelectId() {
            object[] mass = null;
            string id = "";
            try {
                if (dataGrid != null) {
                    DataRowView dataRowView = dataGrid.SelectedItem
                        as DataRowView;
                    if (dataRowView != null) {
                        DataRow dataRow = (DataRow)dataRowView.Row;
                        mass = dataRow.ItemArray;
                    }
                }
                id = mass[0].ToString();
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return id;
        }

        public void DelitRowDB(string SqlCommandDelite) {
            try {
                sqlConnection.Open();
                SqlCommand = new SqlCommand(SqlCommandDelite, sqlConnection);
                SqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "ошибка", MessageBoxButton.OK);
            }
            finally {
                sqlConnection.Close();
            }
        }
    }
}
