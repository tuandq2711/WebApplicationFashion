using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FashionGo.Models.Entities;
using FashionGo.Models;

namespace FashionGo.Controllers
{
    public class HomeController : BaseController
    {
        public DateTime now = new DateTime();

        public ActionResult Index()
        {
            //Saleoff product
            var saleOffProducts = db.Products.Where(p=>p.Actived == true).Where(p => p.IsSpecial == true).Take(20);
            ViewBag.saleOffProducts = saleOffProducts;

            //Lastest Product
            var lastProducts = db.Products.Where(p => p.Actived == true).OrderByDescending(p=>p.IsNew).OrderBy(p => p.CreateDate).Take(20);
            ViewBag.lastProducts = lastProducts;

            var model = db.ProductCategories.Where(c=>c.ParentId == null).OrderBy(c=>c.DisplayOrder);

            return View(model);
        }

        
        public ActionResult _AboutUs()
        {
            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Liên hệ FashionGo";

            return View();
        }

        public ActionResult Category()
        {
            var model = db.ProductCategories.OrderBy(p => p.DisplayOrder);
            return PartialView("Partials/_Category", model);
        }

        public ActionResult Header()
        {
            var today = new DateTime();
            var cart = ShoppingCart.Cart;
            try
            {
                var cats = db.ProductCategories.OrderBy(p => p.DisplayOrder).ToList();
                ViewBag.ProductCategories = cats;
            }
            catch
            {

            }

            try
            {
                // Lấy cookie cũ tên views
                var wishlist = Request.Cookies["wishlist"];
                // Nếu chưa có cookie cũ -> tạo mới
                if (wishlist == null)
                {
                    wishlist = new HttpCookie("wishlist");
                }
                ViewBag.Count = wishlist.Values.Count;
            }
            catch
            {

            }

            ViewBag.Provinces = db.Provinces.OrderBy(p => p.Name).ToList();

            ViewBag.BannerTop = db.Banners.Where(b => b.BannerTypeId == 1)
                                        .Where(b => b.BannerPositionId == 1)
                                        .Where(b => b.Active == true)
                                        .Where(b => b.StartDate >= today)
                                        .Where(b => b.EndDate > today).FirstOrDefault();

            return PartialView("Partials/_Header", cart.Items);
        }

        public ActionResult _SliderShow()
        {
            var model = db.Sliders.OrderByDescending(s=>s.Id).Take(8).ToList();
            return PartialView(model);
        }

        public ActionResult _Testimonials()
        {
            var testimonials = db.Testimonials.Take(6).ToList();
            return PartialView(testimonials);
        }

        public ActionResult _AllShopCategory()
        {
            var productCategories = db.ProductCategories.Where(c => c.ParentId == null).Take(5).ToList();
            return PartialView(productCategories);
        }

        public ActionResult _TosWidget()
        {
            return PartialView();
        }


        public ActionResult Footer()
        {
            ViewBag.MenuGioiThieu = db.Menus.Where(m=>m.LocationId ==1).ToList();
            ViewBag.MenuTroGiup = db.Menus.Where(m => m.LocationId == 2).ToList();

            return PartialView("Partials/_Footer");
        }


        public ActionResult Culture(string id)
        {
            HttpCookie cookie = Request.Cookies["Culture"];
            if (cookie == null)
            {
                cookie = new HttpCookie("Culture", id);
            }
            cookie.Value = id;
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.SetCookie(cookie);

            return Redirect("/");
        }

        public ActionResult PopoupBanner()
        {
            //var today = new DateTime();
            Banner popup = db.Banners.Where(b => b.BannerTypeId == 2)
                            .Where(b => b.Active == true).FirstOrDefault();

            return PartialView("Partials/_PopupBaner", popup);
        }


        public ActionResult NotFound()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjaxGetDistrictByProvice(string provinceId)
        {
            //var m = db.Provinces.Find(provinceId);
            return PartialView(db.Districts.Where(d => d.ProvinceId == provinceId).ToList());
        }

    }
}