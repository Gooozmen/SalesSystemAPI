namespace SalesSystemAPI.Controllers.DTOS.SoldProductDTO
{
    public class PostSoldProduct
    {

        private int productId;
        private int stock;
        private int saleId;

        public int ProductId { get; set; }
        public int Stock { get; set; }
        public int SaleId { get; set; }
    }
}
