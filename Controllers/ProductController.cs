using Microsoft.AspNetCore.Mvc;
using SalesSystemAPI.Controllers.DTOS;
using SalesSystemAPI.Controllers.DTOS.ProductDTO;
using SalesSystemAPI.Model;
using SalesSystemAPI.Repository;

namespace SalesSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public List<Product> Get()
        {
            try
            {
                return ProductHandler.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("Create")]
        public bool Post([FromBody] PostProduct product)
        {
            try
            {
                return ProductHandler.Create(new Product
                {
                    Descriptions = product.Descriptions,
                    Price = product.Price,
                    SalePrice = product.SalePrice,
                    Stock = product.Stock,
                    EmployeeId = product.EmployeeId,
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
        public bool Put([FromBody] PutProduct product)
        {
            try
            {
                return ProductHandler.Update(new Product
                {
                    Id = product.Id,
                    Descriptions = product.Descriptions,
                    Price = product.Price,
                    SalePrice = product.SalePrice,
                    Stock = product.Stock,
                    EmployeeId = product.EmployeeId,
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
                return ProductHandler.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
