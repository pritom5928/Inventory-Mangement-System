using PurchaseSystem.Common;
using PurchaseSystem.DTO;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class ComBillController : Controller
    {
        ApplicationDbContext db;
        public ComBillController()
        {
            db = new ApplicationDbContext();
        }

        // GET: ComBill
        public ActionResult Index()
        {
            return View();
        }

        public ComBillDTO GetPageData()
        {
            ComBillDTO comBill = new ComBillDTO();

            if (User.IsInRole("Admin"))
            {
                var prodList = from productlist in db.ProductMsts
                               select new ProductDDD_DTO
                               {
                                   ProductId = productlist.pk_ProductId,
                                   ProductName = productlist.ProductName
                               };


                comBill.ProductList = prodList.ToList();

            }

            return comBill;
        }

        [HttpGet]
        public ActionResult SaveUpdateBill(int id)
        {
            ComBillDTO items = new ComBillDTO();

            CustomerMst cust;

            if (User.IsInRole("Admin"))
            {
                cust = db.CustomerMsts.FirstOrDefault(s => s.pk_Cusid == id);
            }

            else
            {
                cust = db.CustomerMsts.FirstOrDefault(s => s.pk_Cusid == id && s.UserName == User.Identity.Name);
            }

            
            items = GetPageData();
            items.CustomerMst = cust;
            return View(items);
        }

        [HttpGet]
        public JsonResult GetAllProductsBySearch(string productName)
        {
            IEnumerable<ProductDDD_DTO> productList = new List<ProductDDD_DTO>();

            if (User.IsInRole("Admin"))
            {
                productList = from item in db.ProductMsts
                              where item.ProductName.Contains(productName)
                              select new ProductDDD_DTO
                              {
                                  ProductId = item.pk_ProductId,
                                  ProductName = item.ProductName
                              };
            }

            return Json(productList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CalculatePrice(int selectedProductId, double quantity)
        {
            ProductMst product = db.ProductMsts.FirstOrDefault(s => s.pk_ProductId == selectedProductId);

            double price = quantity * product.SellingUptoPrice;

            return Json(price, JsonRequestBehavior.AllowGet);
        }
    }
}