namespace SalesSystemAPI.Controllers.DTOS.SoldProductDTO
{
    public class SoldProductInfo
    {
        private int id;
        private int productId;
        private string descriptions;
        private int salePricePerUnit;
        private int quantity;
        private int total;
        private int saleId;

        public int Id { get; set;}
        public int ProductId { get; set; }
        public string Descriptions { get; set; }
        public int SalePricePerUnit { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public int SaleId { get; set; }
    }
}
