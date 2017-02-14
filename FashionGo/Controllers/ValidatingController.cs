using FashionGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionGo.Controllers
{
    public class ValidatingController : BaseController
    {
        protected ApplicationDbContext sdb = new ApplicationDbContext();
        public JsonResult IsUserExists(string Email)   
            {
                var model = new { valid = !sdb.Users.Any(x => x.Email == Email) };
                return Json(model, JsonRequestBehavior.AllowGet);
	        //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
	       
	        }


        public JsonResult IsRoleExists(string NewRoleName)
        {
            var model = new { valid = !sdb.Roles.Any(x => x.Name == NewRoleName) };
            return Json(model, JsonRequestBehavior.AllowGet);
            

        }
        

    }
}