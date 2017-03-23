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

        private void UpdateProductsQuantity()
        {
            int productQuantity = new Random().Next();

            try
            {
                _command.CommandText = @"UPDATE [dbo].[Product] SET [QuantityAvailable] = " + productQuantity;

                _connection.Open();
                int effectedRows = _command.ExecuteNonQuery();

                MakeUpdateRecordCountLabelVisible(makeVisible: true);
                SetUpdateRecordCountLabelText(message: effectedRows + " Rows Effected");
            }
            catch (Exception exp) { throw exp; }
            finally
            {
                _connection.Close();
            }
        }

        protected void updateQty_Click(object sender, EventArgs e)
        {
            //Poi: This encapsulation (UpdateProductsQuantity) over update operation is required because
            //the OPENED connection MUST BE closed before another SQL operation is performed
            UpdateProductsQuantity();

            LoadAllProductsGrid();
        }

        private void DeleteProduct()
        {
            try
            {
                _command.CommandText = @"DELETE FROM [dbo].[Product] WHERE [ProductId] = (SELECT MIN([ProductId]) FROM [dbo].[Product])";
                _connection.Open();
                int effectedRows = _command.ExecuteNonQuery();

                MakeUpdateRecordCountLabelVisible(makeVisible: true);
                SetUpdateRecordCountLabelText(message: effectedRows + " Rows Effected");
            }
            catch (Exception exp) { throw exp; }
            finally
            {
                _connection.Close();
            }
        }

        protected void deleteProduct_Click(object sender, EventArgs e)
        {
            DeleteProduct();
            LoadAllProductsGrid();
        }

        private void MakeUpdateRecordCountLabelVisible(bool makeVisible) => updateRecordCount.Visible = makeVisible;

        private void SetUpdateRecordCountLabelText(string message) => updateRecordCount.Text = message;

        protected void insertProductBtn_Click(object sender, EventArgs e)
        {
            InsertProduct();
            LoadAllProductsGrid();
        }

        private void InsertProduct()
        {
            try
            {
                string productName = productNameTxt.Text.Trim();
                if (string.IsNullOrEmpty(productName)) return;

                int productQuantity = new Random().Next();

                _command.CommandText = @"INSERT INTO [dbo].[Product] ([ProductName], [QuantityAvailable]) VALUES('" + productName + "', " + productQuantity + ")";
                _connection.Open();
                int effectedRows = _command.ExecuteNonQuery();

                MakeUpdateRecordCountLabelVisible(makeVisible: true);
                SetUpdateRecordCountLabelText(message: effectedRows + " Rows Effected");
                productNameTxt.Text = string.Empty;
            }
            catch (Exception exp) { throw exp; }
            finally
            {
                _connection.Close();
            }
        }
    }
}