using Microsoft.AspNetCore.Mvc;
using SalesSystemAPI.Controllers.DTOS;
using SalesSystemAPI.Model;
using SalesSystemAPI.Repository;

namespace SalesSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogInController : ControllerBase
    {
        [HttpGet(Name = "LogIn")]
        public bool ValidateAccess([FromBody] ValidateEmployee employee)
        {
            try
            {
                return EmployeeHandler.LogIn( new Employee
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
    }
}
