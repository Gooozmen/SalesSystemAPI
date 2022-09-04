using SalesSystemAPI.Model;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using SalesSystemAPI.Controllers.DTOS.ProductDTO;
using SalesSystemAPI.Repository;
using SalesSystemAPI.Controllers.DTOS.SoldProductDTO;

namespace SalesSystemAPI.Repository
{
    public static class SoldProductHandler
    {
        public const string connectionString = "Server=LAPTOP-SL2QNK3P ;Database=SalesSystem ;Trusted_Connection=True;";

        public static bool Delete(int id)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryDelete = "DELETE SoldProduct WHERE ProductId = @productId";

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

        public static bool DeleteBySaleId(int id)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryDelete = "DELETE SoldProduct WHERE SaleId = @id";

                    SqlParameter parameterProductId = new SqlParameter("id", System.Data.SqlDbType.Int) { Value = id };

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

        public static bool Create(SoldProduct soldProduct)
        {
            bool result = false;
            try
            {
                int saleId =  SaleHandler.Create();

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryInsert = "INSERT INTO SoldProduct(Stock, ProductId, SaleId)" +
                                         "VALUES(@stock, @productId, @saleId)";

                    SqlParameter parameterStock = new SqlParameter("stock", System.Data.SqlDbType.BigInt) { Value = soldProduct.Stock };
                    SqlParameter parameterProductId = new SqlParameter("productId", System.Data.SqlDbType.BigInt) { Value = soldProduct.ProductId };
                    SqlParameter parameterSaleId = new SqlParameter("saleId", System.Data.SqlDbType.BigInt) { Value = saleId };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parameterStock);
                        sqlCommand.Parameters.Add(parameterProductId);
                        sqlCommand.Parameters.Add(parameterSaleId);

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

        public static bool DecreaseProductStock(SoldProduct soldProduct)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryUpdate = "UPDATE Product SET Stock = Stock - @soldProductStock WHERE Id = @productId";

                    SqlParameter parameterSoldProductStock = new SqlParameter("soldProductStock", System.Data.SqlDbType.BigInt) { Value = soldProduct.Stock };
                    SqlParameter parameterProductId = new SqlParameter("productId", System.Data.SqlDbType.BigInt) { Value = soldProduct.ProductId};

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
  
                        sqlCommand.Parameters.Add(parameterSoldProductStock);
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

        public static List<Int32> GetSoldProductsIds()
        {
            List<Int32> soldProductsIds = new List<Int32>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySelect = "SELECT * From SoldProduct";

                    using (SqlCommand command = new SqlCommand(querySelect, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    SoldProduct soldProduct = new SoldProduct();

                                    soldProduct.Id = Convert.ToInt32(reader["Id"]);
                                    soldProduct.ProductId = Convert.ToInt32(reader["ProductId"]);
                                    soldProduct.Stock = Convert.ToInt32(reader["Stock"]);
                                    soldProduct.SaleId = Convert.ToInt32(reader["SaleId"]);

                                    soldProductsIds.Add(soldProduct.Id);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return soldProductsIds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return soldProductsIds;
            }
        }

        public static SoldProductInfo GetById(int id)
        {
            SoldProductInfo soldProductInfo = new SoldProductInfo();
            Product product = new Product();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySelect = "SELECT * From SoldProduct WHERE Id = @id";

                    SqlParameter parameterId = new SqlParameter("id", System.Data.SqlDbType.BigInt) { Value = id };

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(querySelect, connection))
                    {
                        command.Parameters.Add(parameterId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    soldProductInfo.Id = Convert.ToInt32(reader["Id"]);
                                    soldProductInfo.ProductId = Convert.ToInt32(reader["ProductId"]);

                                    product = ProductHandler.GetById(soldProductInfo.ProductId);

                                    soldProductInfo.Descriptions = product.Descriptions;
                                    soldProductInfo.SalePricePerUnit = product.SalePrice;
                                    soldProductInfo.Quantity = Convert.ToInt32(reader["Stock"]);
                                    soldProductInfo.Total = soldProductInfo.Quantity * soldProductInfo.SalePricePerUnit; 
                                    soldProductInfo.SaleId = Convert.ToInt32(reader["SaleId"]);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return soldProductInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return soldProductInfo;
            }
        }

        public static List<SoldProductInfo> GetProducts()
        {
            List<SoldProductInfo> products = new List<SoldProductInfo>();

            try
            {
                List<Int32> Ids = GetSoldProductsIds();

                foreach (Int32 id in Ids)
                {
                    SoldProductInfo obtainedProduct = GetById(id);
                    products.Add(obtainedProduct);
                }
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return products;
            }
        }
    }
}
