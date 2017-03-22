using System;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADO_101_WinForm.Forms
{
    public partial class StudentGrid : Form
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;
        private readonly string _connectionString;

        public StudentGrid()
        {
            InitializeComponent();

            _connectionString = ConfigurationManager.ConnectionStrings["SchoolDbConnectionString"].ConnectionString;

            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand
            {
                Connection = _connection
            };
        }

        private void StudentGrid_Load(object sender, System.EventArgs e)
        {
            try
            {
                _command.CommandText = @"SELECT StudentID, StudentName, StandardId FROM [dbo].[Student]";

                _connection.Open();

                BindingSource source = new BindingSource
                {
                    DataSource = _command.ExecuteReader()
                };

                studentGridView.DataSource = source;
            }
            catch (Exception) { }
            finally
            {
                _connection.Close();
            }
        }
    }
}
