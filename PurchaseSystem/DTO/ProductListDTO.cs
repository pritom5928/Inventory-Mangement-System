using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.DTO
{
    public class ProductListDTO
    {
        public int pk_ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public double OriPrice { get; set; }
        public double SellingUptoPrice { get; set; }
        public double ProductQuantity { get; set; }
    }
}