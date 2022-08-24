using Microsoft.AspNetCore.Mvc;
using SalesSystemAPI.Controllers.DTOS;
using SalesSystemAPI.Model;
using SalesSystemAPI.Repository;

namespace SalesSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController
    {
        [HttpPost(Name = "CreateSale")]
        public bool Post([FromBody] List<SoldProduct> soldProducts)
        {
            try
            {
                return SaleHandler.LoadSoldProducts(soldProducts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
