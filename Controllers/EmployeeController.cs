using Microsoft.AspNetCore.Mvc;
using SalesSystemAPI.Controllers.DTOS;
using SalesSystemAPI.Model;
using SalesSystemAPI.Repository;

namespace SalesSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet(Name = "GetEmployees")]
        public List<Employee> Get()
        {
            try
            {
                return EmployeeHandler.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }


        [HttpPut(Name = "UpdateEmployee")]
        public bool Put([FromBody] PutEmployee employee)
        {
            try
            {
                return EmployeeHandler.Update(new Employee
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    LogOnCredential = employee.LogOnCredential,
                    Password = employee.Password,
                    Mail = employee.Mail,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        [HttpDelete(Name = "DeleteEmployee")]
        public bool Delete([FromBody] int id)
        {
            try
            {
                return EmployeeHandler.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return false;
            }
        }


        [HttpPost(Name = "CreateEmployee")]
        public bool Post([FromBody] PostEmployee employee)
        {
            try
            {
                return EmployeeHandler.Create(new Employee
                {
                    Name = employee.Name,
                    LastName = employee.LastName,
                    LogOnCredential = employee.LogOnCredential,
                    Password = employee.Password,
                    Mail = employee.Mail,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
