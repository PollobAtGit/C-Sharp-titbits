using System;
using System.Web.UI;
using System.Data.SqlClient;

namespace ADO_101.ASPXs
{
    public partial class Students : Page
    {
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public Students()
        {
            _connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=SSPI");
            _command = new SqlCommand
            {
                Connection = _connection
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Poi: Connection can not be closed from method 'GetAllStudent' because DataBinding occurs
            //when DataBind() is invoked. So if method 'GetAllStudent' closes the connection than
            //exception is thrown

            _connection.Open();

            StudentsGrdVw.DataSource = GetAllStudent();
            StudentsGrdVw.DataBind();

            _connection.Close();
        }

        private SqlDataReader GetAllStudent()
        {
            try
            {
                _command.CommandText = @"SELECT * FROM [dbo].[Student]";

                //Poi: ExecuteReader from SqlCommand will return a SqlDataReader
                return _command.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
            }
        }
    }
}