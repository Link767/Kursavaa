using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Kursavaa.Class
{
    class ClassCB
    {
        SqlConnection sqlConnection =
        new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public void LoadCity(ComboBox cbCity)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdGity, " +
                    "GityName FROM dbo.[Gity] Order by IdGity ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Gity]");
                cbCity.ItemsSource = dataSet.Tables["[Gity]"].DefaultView;
                cbCity.DisplayMemberPath = dataSet.Tables["[Gity]"].Columns["GityName"].ToString();
                cbCity.SelectedValuePath = dataSet.Tables["[Gity]"].Columns["IdGity"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void LoadStreet(ComboBox cbStreet)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdStreet, " +
                    "StreetName FROM dbo.[Street] Order by IdStreet ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Street]");
                cbStreet.ItemsSource = dataSet.Tables["[Street]"].DefaultView;
                cbStreet.DisplayMemberPath = dataSet.Tables["[Street]"].Columns["StreetName"].ToString();
                cbStreet.SelectedValuePath = dataSet.Tables["[Street]"].Columns["IdStreet"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void LoadFOI(ComboBox cdStaff)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdStaff, " +
                    "Name FROM dbo.[Staff] Order by IdStaff ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Staff]");
                cdStaff.ItemsSource = dataSet.Tables["[Staff]"].DefaultView;
                cdStaff.DisplayMemberPath = dataSet.Tables["[Staff]"].Columns["Name"].ToString();
                cdStaff.SelectedValuePath = dataSet.Tables["[Staff]"].Columns["IdStaff"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void LoadGender(ComboBox cbGender)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdGender, " +
                    "GenderName FROM dbo.[Gender] Order by IdGender ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Gender]");
                cbGender.ItemsSource = dataSet.Tables["[Gender]"].DefaultView;
                cbGender.DisplayMemberPath = dataSet.Tables["[Gender]"].Columns["GenderName"].ToString();
                cbGender.SelectedValuePath = dataSet.Tables["[Gender]"].Columns["IdGender"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void LoadMaritalStatus(ComboBox cbMaritalStatus)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdMaritalStatus, " +
                    "MaritalStatusName FROM dbo.[MaritalStatus] Order by IdGender ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[MaritalStatus]");
                cbMaritalStatus.ItemsSource = dataSet.Tables["[MaritalStatus]"].DefaultView;
                cbMaritalStatus.DisplayMemberPath = dataSet.Tables["[MaritalStatus]"].Columns["MaritalStatusName"].ToString();
                cbMaritalStatus.SelectedValuePath = dataSet.Tables["[MaritalStatus]"].Columns["IdMaritalStatus"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }   
}
