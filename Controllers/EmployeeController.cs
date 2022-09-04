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
        [HttpGet]
        [Route("GetAll")]
        public List<Employee> Get()
        {
            try
            {
                return EmployeeHandler.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("GetNameById")]
        public string GetNameByID(int id)
        {
            try
            {
                Employee employee = EmployeeHandler.GetById(id);
                return employee.Name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public Employee GetEmployee(int id)
        {
            try
            {
                return EmployeeHandler.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("Create")]
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

        [HttpPost]
        [Route("LogIn")]
        public bool LogIn([FromBody] ValidateEmployee employee)
        {
            try
            {
                return EmployeeHandler.LogIn(new Employee
                {
                    LogOnCredential = employee.LogOnCredential,
                    Password = employee.Password,
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut]
        [Route("Update")]
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

        [HttpDelete]
        [Route("Delete")]
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
    }
}
