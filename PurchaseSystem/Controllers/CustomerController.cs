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
    public class CustomerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult SaveUpdateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUpdateCustomer(CustomerMst customerMst)
        {
            customerMst.UserName = User.Identity.Name;
            db.CustomerMsts.Add(customerMst);
            db.SaveChanges();
            return Redirect("CustomerList");
        }


        public ActionResult CustomerList()
        {
            return View();
        }

        

        public ActionResult GetAllCustomerListByRole()
        {
            IEnumerable<CustomerMst> customerList = null;

            if (User.IsInRole("Admin"))
            {
                customerList = db.CustomerMsts.ToList();
            }

            else
            {
                customerList = db.CustomerMsts.Where(s => s.UserName == User.Identity.Name);
            }

            return Json( new { data = customerList }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var editedCustomer = db.CustomerMsts.FirstOrDefault(s => s.pk_Cusid == id);
            return View(editedCustomer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerMst customerMst)
        {
            db.CustomerMsts.Add(customerMst);
            db.SaveChanges();

            return Redirect("CustomerList");
        }


        public ActionResult Delete(int id)
        {
            var deletedCustomer = db.CustomerMsts.FirstOrDefault(s => s.pk_Cusid == id);

            db.CustomerMsts.Remove(deletedCustomer);
            db.SaveChanges();

            return Redirect("CustomerList");
        }
    }
}