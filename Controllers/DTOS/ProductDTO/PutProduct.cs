namespace SalesSystemAPI.Controllers.DTOS.ProductDTO
{
    public class PutProduct
    {
        private int id;
        private string descriptions;
        private int price;
        private int salePrice;
        private int stock;
        private int employeeId;

        public int Id { get; set; }
        public string Descriptions { get; set; }
        public int Price { get; set; }
        public int SalePrice { get; set; }
        public int Stock { get; set; }
        public int EmployeeId { get; set; }
    }
}
