using SalesSystemAPI.Model;
using System.Data.SqlClient;

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

        public static bool Create(SoldProduct soldProduct, int saleId)
        {
            bool result = false;
            try
            {
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
    }
}
