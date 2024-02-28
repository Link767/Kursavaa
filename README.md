Код1
        SqlConnection sqlConnection = new SqlConnection(App.ConnectionString());
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        ClassCB classCB;
        Kassa kassa;

        public static string IdAddress { get; set; }
        public KassaAdd()
        {
            InitializeComponent();
            classCB = new ClassCB();
            kassa = new Kassa();
        }

        private void AddKassa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Добавление адреса
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Insert into dbo.[Address] " +
                    "(HousNumber, IdStreet) " +
                    "Values " +
                    "(@HousNumber, " +
                "@IdStreet)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("HousNumber", TbHouseNumber.Text);
                sqlCommand.Parameters.AddWithValue("IdStreet", CbStreet.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();

                //получение IdAddress
                sqlCommand = new SqlCommand("Select IdAddress from dbo.Address " +
                   $"where HousNumber = {TbHouseNumber.Text}", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                IdAddress = dataReader[0].ToString();
                dataReader.Close();

                //добавление кассы
                sqlCommand = new SqlCommand("Insert into dbo.[Kassa] " +
                    "(IdAddress, IdStaff) " +
                    "Values " +
                    "(@IdAddress, " +
                "@IdStaff)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("IdAddress", IdAddress.ToString());
                sqlCommand.Parameters.AddWithValue("IdStaff", CbFIO.SelectedValue.ToString());
                sqlCommand.ExecuteNonQuery();




                MessageBox.Show("Добавление кассы прошло успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                new Kassa().Show();
                Close();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadCity(CbCity);
            classCB.LoadStreet(CbStreet);
            classCB.LoadFIO(CbFIO);
        }
    }







    код 2
     public class ClassCB
 {
     SqlConnection sqlConnection =
          new SqlConnection(App.ConnectionString());
     SqlDataAdapter dataAdapter;
     SqlDataReader dataReader;
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

     public void LoadFIO(ComboBox cbFIO)
     {
         try
         {
             sqlConnection.Open();
             dataAdapter = new SqlDataAdapter("SELECT IdStaff, " +
                 "Name FROM dbo.[Staff] Order by IdStaff ASC",
                 sqlConnection);
             dataSet = new DataSet();
             dataAdapter.Fill(dataSet, "[Staff]");
             cbFIO.ItemsSource = dataSet.Tables["[Staff]"].DefaultView;
             cbFIO.DisplayMemberPath = dataSet.Tables["[Staff]"].Columns["Name"].ToString();
             cbFIO.SelectedValuePath = dataSet.Tables["[Staff]"].Columns["IdStaff"].ToString();
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
