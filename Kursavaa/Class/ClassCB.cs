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
                    "MaritalStatusName FROM dbo.[MaritalStatus] Order by IdMaritalStatus ASC",
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

        public void LoadStatus(ComboBox cbStatus)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdStatus, " +
                    "StatusName FROM dbo.[Status] Order by IdStatus ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Status]");
                cbStatus.ItemsSource = dataSet.Tables["[Status]"].DefaultView;
                cbStatus.DisplayMemberPath = dataSet.Tables["[Status]"].Columns["StatusName"].ToString();
                cbStatus.SelectedValuePath = dataSet.Tables["[Status]"].Columns["IdStatus"].ToString();
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

        public void LoadAddress(ComboBox cbAddress)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdAddress, " +
                    "HousNumber FROM dbo.[Address] Order by IdAddress ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Address]");
                cbAddress.ItemsSource = dataSet.Tables["[Address]"].DefaultView;
                cbAddress.DisplayMemberPath = dataSet.Tables["[Address]"].Columns["HousNumber"].ToString();
                cbAddress.SelectedValuePath = dataSet.Tables["[Address]"].Columns["IdAddress"].ToString();
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

        public void LoadYear(ComboBox cdYear)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdYear, " +
                    "YearName FROM dbo.[Year] Order by IdYear ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Year]");
                cdYear.ItemsSource = dataSet.Tables["[Year]"].DefaultView;
                cdYear.DisplayMemberPath = dataSet.Tables["[Year]"].Columns["YearName"].ToString();
                cdYear.SelectedValuePath = dataSet.Tables["[Year]"].Columns["IdYear"].ToString();
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

        public void LoadMonth(ComboBox cdMonth)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdMonth, " +
                    "MonthName FROM dbo.[Month] Order by IdMonth ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Month]");
                cdMonth.ItemsSource = dataSet.Tables["[Month]"].DefaultView;
                cdMonth.DisplayMemberPath = dataSet.Tables["[Month]"].Columns["MonthName"].ToString();
                cdMonth.SelectedValuePath = dataSet.Tables["[Month]"].Columns["IdMonth"].ToString();
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

        public void LoadPoint(ComboBox cbPoint)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdPoint, " +
                    "PointName FROM dbo.[Point] Order by IdPoint ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Point]");
                cbPoint.ItemsSource = dataSet.Tables["[Point]"].DefaultView;
                cbPoint.DisplayMemberPath = dataSet.Tables["[Point]"].Columns["PointName"].ToString();
                cbPoint.SelectedValuePath = dataSet.Tables["[Point]"].Columns["IdPoint"].ToString();
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

        public void LoadProduktName(ComboBox dProdName)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdProdukt, " +
                    "ProduktName FROM dbo.[Produkt] Order by IdProdukt ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Produkt]");
                dProdName.ItemsSource = dataSet.Tables["[Produkt]"].DefaultView;
                dProdName.DisplayMemberPath = dataSet.Tables["[Produkt]"].Columns["ProduktName"].ToString();
                dProdName.SelectedValuePath = dataSet.Tables["[Produkt]"].Columns["IdProdukt"].ToString();
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

        public void LoadProduktCost(ComboBox cbCost)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdProdukt, " +
                    "Cost FROM dbo.[Produkt] Order by IdProdukt ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Produkt]");
                cbCost.ItemsSource = dataSet.Tables["[Produkt]"].DefaultView;
                cbCost.DisplayMemberPath = dataSet.Tables["[Produkt]"].Columns["Cost"].ToString();
                cbCost.SelectedValuePath = dataSet.Tables["[Produkt]"].Columns["IdProdukt"].ToString();
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

        public void LoadUserName(ComboBox cbUserName)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdUser, " +
                    "Name FROM dbo.[User] Order by IdUser ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[User]");
                cbUserName.ItemsSource = dataSet.Tables["[User]"].DefaultView;
                cbUserName.DisplayMemberPath = dataSet.Tables["[User]"].Columns["Name"].ToString();
                cbUserName.SelectedValuePath = dataSet.Tables["[User]"].Columns["IdUser"].ToString();
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

        public void LoadUserSurname(ComboBox cbUserSurname)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdUser, " +
                    "Surname FROM dbo.[User] Order by IdUser ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[User]");
                cbUserSurname.ItemsSource = dataSet.Tables["[User]"].DefaultView;
                cbUserSurname.DisplayMemberPath = dataSet.Tables["[User]"].Columns["Surname"].ToString();
                cbUserSurname.SelectedValuePath = dataSet.Tables["[User]"].Columns["IdUser"].ToString();
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

        public void LoadContry(ComboBox cbContry)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("SELECT IdContry, " +
                    "ContryName FROM dbo.[Contry] Order by IdContry ASC",
                    sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Contry]");
                cbContry.ItemsSource = dataSet.Tables["[Contry]"].DefaultView;
                cbContry.DisplayMemberPath = dataSet.Tables["[Contry]"].Columns["ContryName"].ToString();
                cbContry.SelectedValuePath = dataSet.Tables["[Contry]"].Columns["IdContry"].ToString();
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
