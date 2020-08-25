using PurchaseSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.DTO
{
    public class ComBillDTO
    {
        public ComBillDTO()
        {
            ProductList = new List<ProductDDD_DTO>();
        }


        public int pk_TempBillId { get; set; }
        public int FK_ProductId { get; set; }
        public double ProdQuantity { get; set; }
        public double Price { get; set; }

        public CustomerMst CustomerMst { get; set; }

        public IEnumerable<ProductDDD_DTO> ProductList { get; set; }
    }
}