using SalesSystemAPI.Model;
using System.Data.SqlClient;

namespace SalesSystemAPI.Repository
{
    public static class SaleHandler
    {
        public const string connectionString = "Server=LAPTOP-SL2QNK3P ;Database=SalesSystem ;Trusted_Connection=True;";

        public static int Create()
        {
            int createdSale = 0; 
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryInsert = "INSERT INTO Sale (Comments) " +
                                         "VALUES (' ')";

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            createdSale = GetMostRecentSale();
                        }
                    }
                    sqlConnection.Close();

                    return createdSale;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return createdSale;
            }
        }

        public static int GetMostRecentSale()
        {
            try
            {
                Sale sale = new Sale();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySelect = "SELECT TOP 1 Id FROM Sale ORDER BY Id DESC";
                   
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(querySelect, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    sale.Id = Convert.ToInt32(reader["Id"]);

                                    //sale.Comments = Convert.ToString(reader["Comments"]);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return sale.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static bool Delete(int id)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SoldProductHandler.DeleteBySaleId(id);

                    string queryDeleteSale = "DELETE Sale WHERE Id = @Id";

                    SqlParameter parameterSaleId = new SqlParameter("Id", System.Data.SqlDbType.Int) { Value = id};

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDeleteSale, sqlConnection))
                    {
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
                return result;
            }
        }

    }
}
