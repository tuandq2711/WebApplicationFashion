using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionGo.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        // GET: admin/Default
        public ActionResult Index()
        {
            ViewBag.NewOrders = db.Orders.OrderByDescending(o => o.Id).Take(8).ToList();
            ViewBag.CountOrder = db.Orders.Count();
            ViewBag.CountProduct = db.Products.Count();
            ViewBag.CountUsers = db.Users.Count();

            var model = db.Products.OrderByDescending(p => p.Id).Take(5).ToList();
            return View(model);
        }

        public ActionResult Header()
        {
            ViewBag.Orders = db.Orders.Where(p => p.StatusId == 1).ToList();

            return PartialView("_Header");
        }
    }
}