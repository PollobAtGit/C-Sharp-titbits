using System;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_101.ASPXs
{
    public partial class Products : Page
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;
        private readonly SqlCommand _command;

        public Products()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InventoryDbConnectionString"].ConnectionString;
            _connection = new SqlConnection(_connectionString);
            _command = new SqlCommand
            {
                Connection = _connection
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllProductsGrid();
            LoadProductCountLabel();
        }

        private void LoadProductCountLabel()
        {
            try
            {
                //Poi: Multiple SQL operation MUST BE done from SEPERATE opened connections
                _connection.Open();
                totalProductCount.Text = GetAllProductCount().ToString();
            }
            catch (Exception) { }
            finally
            {
                _connection.Close();
            }
        }

        private void LoadAllProductsGrid()
        {
            try
            {
                //Poi: Connection needs to be open during data is read from SqlDataReader 
                //& that is being done while DataBind() is ran over productsGridView
                _connection.Open();

                productsGridView.DataSource = GetAllProducts();
                productsGridView.DataBind();
            }
            catch (Exception) { }
            finally
            {
                _connection.Close();
            }
        }

        //Poi: Even though not obvious at first glance, all execution path is convered
        private SqlDataReader GetAllProducts()
        {
            try
            {
                _command.CommandText = @"SELECT * FROM [dbo].[Product]";
                return _command.ExecuteReader();
            }
            catch (Exception) { return null; }
            finally { }
        }

        private int? GetAllProductCount()
        {
            try
            {
                _command.CommandText = @"SELECT COUNT(*) FROM [dbo].[Product]";
                return Convert.ToInt32(_command.ExecuteScalar());
            }
            catch (Exception) { return null; }
            finally { }
        }
    }
}