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
    public class ProductController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Product
        [HttpGet]
        public ActionResult AddUpdatProduct()
        {

            var onPageLoadData = new ProductMstDTO
            {
                ProductTypeMstList = _db.ProductTypeMsts.ToList()
            };

            return View(onPageLoadData);
        }


        [HttpPost]
        public ActionResult AddUpdatProduct(ProductMstDTO productMstDTO)
        {
            if (productMstDTO.productMst.pk_ProductId == 0)
            {
                productMstDTO.productMst.UserName = User.Identity.Name;
                _db.ProductMsts.Add(productMstDTO.productMst);
                _db.SaveChanges();
            }

            else
            {
                var editedData = _db.ProductMsts.FirstOrDefault(s => s.pk_ProductId == productMstDTO.productMst.pk_ProductId);

                editedData.fk_prodtypeId = productMstDTO.productMst.fk_prodtypeId;
                editedData.ProductName = productMstDTO.productMst.ProductName;
                editedData.ProductQuantity = productMstDTO.productMst.ProductQuantity;
                editedData.OriPrice = productMstDTO.productMst.OriPrice;
                editedData.SellingUptoPrice = productMstDTO.productMst.SellingUptoPrice;

                _db.SaveChanges();
            }
            

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var EditData = new ProductMstDTO
            {
                productMst = _db.ProductMsts.FirstOrDefault(s => s.pk_ProductId == id),
                ProductTypeMstList = _db.ProductTypeMsts.ToList(),
            };

            return View(EditData);
        }


        public ActionResult Delete(int id)
        {
            var deleteData = _db.ProductMsts.FirstOrDefault(s => s.pk_ProductId == id);

            _db.ProductMsts.Remove(deleteData);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            IEnumerable<ProductListDTO> allproducts;

            if (User.IsInRole("Admin"))
            {
                 allproducts = from a in _db.ProductMsts
                                  join b in _db.ProductTypeMsts on a.fk_prodtypeId equals b.pk_prodtypeId
                                  select new ProductListDTO
                                  {
                                      pk_ProductId = a.pk_ProductId,
                                      ProductType = b.Description,
                                      ProductName = a.ProductName,
                                      OriPrice = a.OriPrice,
                                      SellingUptoPrice = a.SellingUptoPrice,
                                      ProductQuantity = a.ProductQuantity
                                  };
            }

            else
            {
                allproducts = from a in _db.ProductMsts
                              join b in _db.ProductTypeMsts on a.fk_prodtypeId equals b.pk_prodtypeId where a.UserName == User.Identity.Name
                              select new ProductListDTO
                              {
                                  pk_ProductId = a.pk_ProductId,
                                  ProductType = b.Description,
                                  ProductName = a.ProductName,
                                  OriPrice = a.OriPrice,
                                  SellingUptoPrice = a.SellingUptoPrice,
                                  ProductQuantity = a.ProductQuantity
                              };
            }

           
 
            return Json(new { data = allproducts }, JsonRequestBehavior.AllowGet);
        }

    }
}