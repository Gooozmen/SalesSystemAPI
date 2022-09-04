using Microsoft.AspNetCore.Mvc;
using SalesSystemAPI.Controllers.DTOS.SoldProductDTO;
using SalesSystemAPI.Model;
using SalesSystemAPI.Repository;

namespace SalesSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoldProductController : ControllerBase
    {
        [HttpGet]
        [Route("GetSoldProducts")]
        public List<SoldProductInfo> Get()
        {
            try
            {
                return SoldProductHandler.GetProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        [Route("GetSoldProductById")]
        public SoldProductInfo GetById(int id)
        {
            try
            {
                SoldProductInfo soldProductInfo = SoldProductHandler.GetById(id);
                return soldProductInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
