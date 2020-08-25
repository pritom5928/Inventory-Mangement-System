using Microsoft.AspNet.Identity.EntityFramework;
using PurchaseSystem.Common;
using PurchaseSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseSystem.Controllers
{
    [Authorize(Roles = CustomeRole.Admin)]
    public class RoleController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Role
        public ActionResult Create()
        {
            var addRole = new IdentityRole();

            return View(addRole);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole identityRole)
        {
            _db.Roles.Add(identityRole);
            _db.SaveChanges();

            return RedirectToAction("RoleList");
        }


        public ActionResult RoleList()
        {
            var ListOfRoles = _db.Roles.ToList();

            return View(ListOfRoles);
        }
    }
}