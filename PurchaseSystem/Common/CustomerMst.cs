using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurchaseSystem.Common
{
    public class CustomerMst
    {
        [Key]
        public int pk_Cusid { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string Mobileno { get; set; }
    }
}