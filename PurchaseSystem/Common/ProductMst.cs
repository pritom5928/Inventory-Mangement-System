using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseSystem.Common
{
    public class ProductMst
    {
        [Key]
        public int pk_ProductId { get; set; }
        public string UserName { get; set; }
        public int fk_prodtypeId { get; set; }
        public string ProductName { get; set; }
        public double OriPrice { get; set; }
        public double SellingUptoPrice { get; set; }
        public double ProductQuantity { get; set; }
    }
}