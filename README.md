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
