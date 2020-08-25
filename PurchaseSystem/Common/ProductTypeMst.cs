using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseSystem.Common
{
    public class ProductTypeMst
    {
        [Key]
        public int pk_prodtypeId { get; set; }
        public string Description { get; set; }
    }
}