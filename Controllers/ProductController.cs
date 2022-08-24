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
        [HttpPost(Name = "CreateProduct")]
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

        [HttpPut(Name = "UpdateProduct")]
        public bool Put([FromBody] PutProduct product)
        {
            try
            {
                return ProductHandler.Create(new Product
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


    }
}
