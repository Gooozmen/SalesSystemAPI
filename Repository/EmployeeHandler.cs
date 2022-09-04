using SalesSystemAPI.Model;
using System.Data.SqlClient;

namespace SalesSystemAPI.Repository
{
    public static class EmployeeHandler
    {
        public const string connectionString = "Server=LAPTOP-SL2QNK3P ;Database=SalesSystem ;Trusted_Connection=True;";
        public static bool Update(Employee employee)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryUpdate = "UPDATE Employee " +
                                         "SET Name = @name, LastName = @lastName, LogOnCredential = @logOnCredential, Password = @password, Mail = @mail " +
                                         "WHERE Id = @employeeId";


                    SqlParameter parameterName = new SqlParameter("name", System.Data.SqlDbType.VarChar) { Value = employee.Name };
                    SqlParameter parameterLastName = new SqlParameter("lastName", System.Data.SqlDbType.VarChar) { Value = employee.LastName };
                    SqlParameter parameterLogOnCredential = new SqlParameter("logOnCredential", System.Data.SqlDbType.VarChar) { Value = employee.LogOnCredential };
                    SqlParameter parameterPassword = new SqlParameter("password", System.Data.SqlDbType.VarChar) { Value = employee.Password };
                    SqlParameter parameterMail = new SqlParameter("mail", System.Data.SqlDbType.VarChar) { Value = employee.Mail };
                    SqlParameter parameterEmployeeId = new SqlParameter("employeeId", System.Data.SqlDbType.BigInt) { Value = employee.Id }; 

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parameterName);
                        sqlCommand.Parameters.Add(parameterLastName);
                        sqlCommand.Parameters.Add(parameterLogOnCredential);
                        sqlCommand.Parameters.Add(parameterPassword);
                        sqlCommand.Parameters.Add(parameterMail);
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
                    string queryDelete = "DELETE FROM Employee WHERE Id = @employeeId";

                    SqlParameter parameterEmployeeId = new SqlParameter("employeeId", System.Data.SqlDbType.BigInt) { Value = id };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parameterEmployeeId);
                        int numberOfRows = sqlCommand.ExecuteNonQuery();

                        if(numberOfRows > 0)
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
        public static List<Employee> Read()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySearchAll = "SELECT * FROM Employee";

                    using (SqlCommand command = new SqlCommand(querySearchAll, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Employee employee = new Employee();

                                    employee.Id = Convert.ToInt32(reader["Id"]);
                                    employee.Name = Convert.ToString(reader["Name"]);
                                    employee.LastName = Convert.ToString(reader["LastName"]);
                                    employee.LogOnCredential = Convert.ToString(reader["LogOnCredential"]);
                                    employee.Password = Convert.ToString(reader["Password"]);
                                    employee.Mail = Convert.ToString(reader["Mail"]);

                                    employees.Add(employee);
                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return employees;
            }
        }
        public static bool Create(Employee employee)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string queryInsert = "INSERT INTO Employee (Name, LastName, LogOnCredential, Password, Mail) " +
                                         "VALUES (@Name, @LastName, @LogOnCredential, @Password, @Mail)";

                    SqlParameter parameterName = new SqlParameter("Name", System.Data.SqlDbType.VarChar) { Value = employee.Name };
                    SqlParameter parameterLastName = new SqlParameter("LastName", System.Data.SqlDbType.VarChar) { Value = employee.LastName };
                    SqlParameter parameterLogOnCredential = new SqlParameter("LogOnCredential", System.Data.SqlDbType.VarChar) { Value = employee.LogOnCredential };
                    SqlParameter parameterPassword = new SqlParameter("Password", System.Data.SqlDbType.VarChar) { Value = employee.Password };
                    SqlParameter parameterMail = new SqlParameter("Mail", System.Data.SqlDbType.VarChar) { Value = employee.Mail };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parameterName);
                        sqlCommand.Parameters.Add(parameterLastName);
                        sqlCommand.Parameters.Add(parameterLogOnCredential);
                        sqlCommand.Parameters.Add(parameterPassword);
                        sqlCommand.Parameters.Add(parameterMail);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            result = true;
                        }

                        result = true;

                        
                    }
                    sqlConnection.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;
            }
        }
        public static bool LogIn(Employee employee)
        {
            bool loginState = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySearch = "SELECT * FROM Employee WHERE LogOnCredential = @logOnCredential AND Password = @password";

                    SqlParameter parameterLogOnCredential = new SqlParameter("logOnCredential", System.Data.SqlDbType.VarChar) { Value = employee.LogOnCredential };
                    SqlParameter parameterPassword = new SqlParameter("password", System.Data.SqlDbType.VarChar) { Value = employee.Password };

                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(querySearch, connection))
                    {
                        sqlCommand.Parameters.Add(parameterLogOnCredential);
                        sqlCommand.Parameters.Add(parameterPassword);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (Convert.ToString(reader["LogOnCredential"]) == employee.LogOnCredential &
                                        Convert.ToString(reader["Password"]) == employee.Password)
                                    {
                                        employee.LogOnCredential = Convert.ToString(reader["LogOnCredential"]);
                                        employee.Password = Convert.ToString(reader["Password"]);

                                        loginState = true;

                                    }
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                return loginState;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static Employee GetById(int id)
        {
            Employee employee = new Employee();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string querySearchAll = "SELECT * FROM Employee WHERE Id = @id";

                    SqlParameter parameterEmployeeId = new SqlParameter("id", System.Data.SqlDbType.BigInt) { Value = id };

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(querySearchAll, connection))
                    {
                        command.Parameters.Add(parameterEmployeeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    employee.Id = Convert.ToInt32(reader["Id"]);
                                    employee.Name = Convert.ToString(reader["Name"]);
                                    employee.LastName = Convert.ToString(reader["LastName"]);
                                    employee.LogOnCredential = Convert.ToString(reader["LogOnCredential"]);
                                    employee.Password = Convert.ToString(reader["Password"]);
                                    employee.Mail = Convert.ToString(reader["Mail"]);

                                }
                            }
                        }
                        connection.Close();
                    }
                }
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return employee;
            }
        }
    }
}
