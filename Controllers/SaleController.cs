﻿using Microsoft.AspNetCore.Mvc;
using SalesSystemAPI.Controllers.DTOS.SoldProductDTO;
using SalesSystemAPI.Model;
using SalesSystemAPI.Repository;

namespace SalesSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController
    {
        [HttpPost]
        [Route("CreateSale")]
        public bool post([FromBody] PostSoldProduct soldProduct)
        {
            try
            {

                return SoldProductHandler.Create(new SoldProduct
                {
                    ProductId = soldProduct.ProductId,
                    Stock = soldProduct.Stock,
                    SaleId = soldProduct.SaleId,
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
        public bool Delete(int id)
        {
            try
            {
                return SaleHandler.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
