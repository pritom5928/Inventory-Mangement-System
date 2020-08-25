using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    public class ModuleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Module
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateModule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateModule(ModuleMst moduleMst)
        {
            db.ModuleMsts.Add(moduleMst);
            db.SaveChanges();

            return RedirectToAction("ModuleList");
        }


        public ActionResult Edit(int id)
        {
            var existingModule = db.ModuleMsts.FirstOrDefault(s => s.pk_moduleid == id);

            return View("CreateModule", existingModule);
        }


        public ActionResult Delete(int id)
        {
            var existingModule = db.ModuleMsts.FirstOrDefault(s => s.pk_moduleid == id);


            db.ModuleMsts.Remove(existingModule);
            db.SaveChanges();

            return Redirect("ModuleList");
        }

        public ActionResult ModuleList()
        {
           var listOfModule =  db.ModuleMsts.ToList();

            return View(listOfModule);
        }
    }
}