using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    [Authorize]
    public class UserHomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserHome
        public ActionResult DisplayModule()
        {
            List<ModuleMst> activeModuleList;

            if (User.IsInRole("Admin"))
            {
                activeModuleList = db.ModuleMsts.Where(s => s.IsActive == true).ToList();
            }

            else if (User.IsInRole("Cloth Store"))
            {
                activeModuleList = db.ModuleMsts.Where(s => s.IsActive == true && s.pk_moduleid == 1).ToList();
            }

            else
            {
                activeModuleList = db.ModuleMsts.Where(s => s.IsActive == true && s.pk_moduleid == 2).ToList();
            }

            return View(activeModuleList);
        }
    }
}