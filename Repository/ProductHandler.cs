using SalesSystemAPI.Model;
using System.Data.SqlClient;

namespace SalesSystemAPI.Repository
{

    public static class ProductHandler 
    {
        public const string connectionString = "Server=LAPTOP-SL2QNK3P ;Database=SalesSystem ;Trusted_Connection=True;";
        public static List<Product> Read()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySelect = "SELECT * FROM Product";

                    using (SqlCommand command = new SqlCommand(querySelect, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Product product = new Product();

                                    product.Id = Convert.ToInt32(reader["Id"]);
                                    product.Descriptions = Convert.ToString(reader["Descriptions"]);
                                    product.Price = Convert.ToInt32(reader["Price"]);
                                    product.SalePrice = Convert.ToInt32(reader["SalePrice"]);
                                    product.Stock = Convert.ToInt32(reader["Stock"]);
                                    product.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);

                                    products.Add(product);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return products;
            }
        }
        public static bool Create(Product product)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryInsert = "INSERT INTO Product (Descriptions, Price, SalePrice, Stock, EmployeeId) " +
                                         "VALUES (@Descriptions, @Price, @SalePrice, @Stock, @EmployeeId)";

                    SqlParameter parameterDescriptions = new SqlParameter("Descriptions", System.Data.SqlDbType.VarChar) { Value = product.Descriptions };
                    SqlParameter parameterPrice = new SqlParameter("price", System.Data.SqlDbType.BigInt) { Value = product.Price };
                    SqlParameter parameterSalePrice = new SqlParameter("SalePrice", System.Data.SqlDbType.BigInt) { Value = product.SalePrice };
                    SqlParameter parameterStock = new SqlParameter("Stock", System.Data.SqlDbType.BigInt) { Value = product.Stock };
                    SqlParameter parameterEmployeeId = new SqlParameter("EmployeeId", System.Data.SqlDbType.BigInt) { Value = product.EmployeeId };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parameterDescriptions);
                        sqlCommand.Parameters.Add(parameterPrice);
                        sqlCommand.Parameters.Add(parameterSalePrice);
                        sqlCommand.Parameters.Add(parameterStock);
                        sqlCommand.Parameters.Add(parameterEmployeeId);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                            result = true;
                        }
                    }
                    sqlConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool Update(Product product)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryUpdate = "UPDATE Product " +
                        "SET Descriptions = @descriptions, Price = @price, SalePrice = @salePrice, Stock = @stock, EmployeeId = @employeeId " +
                        "WHERE Id = @productId";

                    SqlParameter parameterDescriptions = new SqlParameter("descriptions", System.Data.SqlDbType.VarChar) { Value = product.Descriptions };
                    SqlParameter parameterPrice = new SqlParameter("price", System.Data.SqlDbType.BigInt) { Value = product.Price };
                    SqlParameter parameterSalePrice = new SqlParameter("salePrice", System.Data.SqlDbType.BigInt) { Value = product.SalePrice };
                    SqlParameter parameterStock = new SqlParameter("stock", System.Data.SqlDbType.BigInt) { Value = product.Stock };
                    SqlParameter parameterEmployeeId = new SqlParameter("employeeId", System.Data.SqlDbType.BigInt) { Value = product.EmployeeId };
                    SqlParameter parameterProductId = new SqlParameter("productId", System.Data.SqlDbType.BigInt) { Value = product.Id }; 

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parameterDescriptions);
                        sqlCommand.Parameters.Add(parameterPrice);
                        sqlCommand.Parameters.Add(parameterSalePrice);
                        sqlCommand.Parameters.Add(parameterStock);
                        sqlCommand.Parameters.Add(parameterEmployeeId);
                        sqlCommand.Parameters.Add(parameterProductId);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                            result = true;
                        }
                    }
                    sqlConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }
        }
        public static bool Delete(int id)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryDelete = "DELETE FROM Product WHERE Id = @productId";

                    SqlParameter parameterProductId = new SqlParameter("productId", System.Data.SqlDbType.Int) { Value = id };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parameterProductId);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();

                        if (numberOfRows > 0)
                        {
                            result = true;
                        }
                    }
                    sqlConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }
        }
        public static Product GetById(int id)
        {
            Product product = new Product();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySelect = "SELECT * FROM Product WHERE Id = @id";

                    SqlParameter parameterEmployeeId = new SqlParameter("id", System.Data.SqlDbType.BigInt) { Value = id };

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(querySelect, connection))
                    {
                        command.Parameters.Add(parameterEmployeeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    product.Id = Convert.ToInt32(reader["Id"]);
                                    product.Descriptions = Convert.ToString(reader["Descriptions"]);
                                    product.Price = Convert.ToInt32(reader["Price"]);
                                    product.SalePrice = Convert.ToInt32(reader["SalePrice"]);
                                    product.Stock = Convert.ToInt32(reader["Stock"]);
                                    product.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return product;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return product;
            }
        }
    }
}
