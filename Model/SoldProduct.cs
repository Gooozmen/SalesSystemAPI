﻿namespace SalesSystemAPI.Model
{
    public class SoldProduct
    {
        private int id;
        private int productId;
        private int stock;
        private int saleId;

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public int SaleId { get; set; }

    }
}
