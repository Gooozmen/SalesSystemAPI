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
                    using (SqlCommand command = new SqlCommand("SELECT MAX(Id) FROM Sale", connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    sale.Id = Convert.ToInt32(reader["Id"]);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return sale.Id;
            }
            catch
            {
                return 0;
            }
        }

        //empleado que efectua la venta no es un dato relevante
        //para la tabla venta o producto vendido
        public static bool LoadSoldProducts(List<SoldProduct> products)
        {
            bool result = false;
            try
            {
                int createdSale = SaleHandler.Create();

                foreach (SoldProduct item in products)
                {
                    SoldProductHandler.Create(item,createdSale);
                    SoldProductHandler.DecreaseProductStock(item);
                }

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }
        }
    }
}
