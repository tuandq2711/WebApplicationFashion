using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionGo.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Menu
        public ActionResult _MainMenu()
        {
            //Mainmenu Location = 8
            var menus = db.Menus.Where(m => m.LocationId == 8).ToList();
            return PartialView(menus);
        }

        public ActionResult _MobileMenu()
        {
            //Mainmenu Location = 8
            var menus = db.Menus.Where(m => m.LocationId == 8).ToList();
            return PartialView(menus);
        }
    }
}