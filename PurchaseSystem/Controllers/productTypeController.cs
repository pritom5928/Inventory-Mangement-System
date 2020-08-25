using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class productTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public productTypeController()
        {
            _db = new ApplicationDbContext();
        }

        // GET: productType
        public ActionResult Create()
        {
            return View("CreateUpdateForm");
        }

        [HttpPost]
        public ActionResult CreateUpdateForm(ProductTypeMst productTypeMst)
        {
            _db.ProductTypeMsts.Add(productTypeMst);
            _db.SaveChanges();

            return View();
        }

        public ActionResult productTypeList()
        {
            var allProductType = _db.ProductTypeMsts.ToList();

            return View(allProductType);
        }

        public ActionResult Edit(int id)
        {
            var EditProduct = _db.ProductTypeMsts.FirstOrDefault(s => s.pk_prodtypeId == id);

            return View("CreateUpdateForm", EditProduct);
        }

    }
}