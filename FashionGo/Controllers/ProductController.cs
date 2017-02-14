using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FashionGo.Models.Entities;
using FashionGo.Models.Dao;
using System.Net;

namespace FashionGo.Controllers
{
    public class ProductController : BaseController
    {
        int pageSize = 20;
        public List<Product> Products
        {
            get
            {
                // Lấy ra từ Session
                var list = Session["Products"] as List<Product>;
                if (list == null) // chưa có trong Session
                {
                    list = new List<Product>();
                    Session["Products"] = list; // bỏ vào Session
                }
                return list;
            }
        }

        public ActionResult ProductCategory(int id, int? page)
        {
            int pageNumber = (page ?? 1);

            var cat = db.ProductCategories.Find(id);
            if (cat == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var model = cat.AllProducts(100);
            ViewBag.Category = cat;
            return View(model.ToPagedList(pageNumber, pageSize ));
        }


        //TÌm kiếm sản phẩm theo từ khóa khớp với tên chuyên mục hoặc tên sản phẩm
        [HttpGet]
        public ActionResult Search(string keyword, int? page)
        {
            ViewBag.keyword = keyword;
            var results = (from s in db.Products.ToList()
                           where ( (string.IsNullOrEmpty(keyword) ? true : s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) )) || 
                                 ( (string.IsNullOrEmpty(keyword) ? true : s.ProductCategory.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ))
                           select s).Where(p => p.Actived == true);
            int pageSize = 20;
            int pageNumber = (page ?? 1);

            if (results.Count() == 0)
            {
                ViewBag.notice = "Không tìm thấy sản phẩm phù hợp với từ khóa: \"" + keyword + "\"";
                return View(db.Products.Where(p => p.Actived == true).ToList().ToPagedList(pageNumber, pageSize));
            }

            ViewBag.Title = "Có " + results.Count() + " sản phẩm phù hợp với từ khóa: \"" + keyword + "\"";
            return View(results.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ProductTags()
        {
            var model = db.ProductCategories.ToList();
            return PartialView("Partials/_ProductTags", model);
        }

        public ActionResult Detail(int? Id, string Slug)
        {
            if (Id == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var model = db.Products.Where(p => p.Actived == true).SingleOrDefault(p => p.Id == Id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            model.Views++;
            db.SaveChanges();

            //san pham vua xem
            var list = Products;
            var m = list.SingleOrDefault(c => c.Id == Id);
            if(m==null)
            {
                list.Add(model);
            }

            if (list.Count > 10)
            {
                ViewBag.Views = list.Take(10);
            }
            else
            {
                ViewBag.Views = list;
            }

            ViewBag.PageHelp = db.Pages.SingleOrDefault(p=>p.Id == 8);
            //ViewBag.Views = list;
            return View("Detail", model);
        }

        public ActionResult AddToWishList(int Id)
        {
            try
            {
                // Lấy cookie cũ tên views
                var wishlist = Request.Cookies["wishlist"];
                var ProductName = db.Products.Where(p => p.Actived == true).SingleOrDefault(p => p.Id == Id);

                if (ProductName == null)
                {
                    return RedirectToAction("NotFound", "Home");
                }

                // Nếu chưa có cookie cũ -> tạo mới
                if (wishlist == null)
                {
                    wishlist = new HttpCookie("wishlist");
                }
                // Bổ sung mặt hàng đã xem vào cookie
                if(wishlist[Id.ToString()]==null)
                {
                    
                    wishlist.Values[Id.ToString()] = Id.ToString();
                     //Success(string.Format("<b><h4>{0}</h4></b> was add to wish list successfully.", ProductName.Name), true);
                }
                
                // Đặt thời hạn tồn tại của cookie
                wishlist.Expires = DateTime.Now.AddMonths(1);
                // Gửi cookie về client để lưu lại
                Response.Cookies.Add(wishlist);

                // Lấy List<int> chứa mã hàng đã xem từ cookie
                var keys = wishlist.Values
                    .AllKeys.Select(k => int.Parse(k)).ToList();
                // Truy vấn háng đãn xem
                ViewBag.WishList = db.Products
                    .Where(p => keys.Contains(p.Id));
                ViewBag.Count = wishlist.Values.Count;
            }
            catch
            {

            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult MyWishList()
        {
            var wishlist = Request.Cookies["wishlist"];
            // Nếu chưa có cookie cũ -> tạo mới
            if (wishlist == null)
            {
                wishlist = new HttpCookie("wishlist");
            }
            var keys = wishlist.Values
                .AllKeys.Select(k => int.Parse(k)).ToList();
            // Truy vấn háng đãn xem
            ViewBag.WishList = db.Products
                .Where(p => keys.Contains(p.Id))
                .Take(10);
            return View();
        }

        public ActionResult RemoveFromWishList(int Id)
        {
            try
            {
                var ProductName = db.Products.SingleOrDefault(p => p.Id == Id);
                var wishlist = Request.Cookies["wishlist"];

                if (wishlist.HasKeys)
                {
                    wishlist.Values.Remove(Id.ToString());
                }
                Response.SetCookie(wishlist);
                //Success(string.Format("<b><h4>{0}</h4></b> was remove from wish list successfully.", ProductName.Name), true);
            }
            catch
            {

            }
         

            // Bổ sung mặt hàng đã xem vào cookie
           // wishlist.Values[Id.ToString()].Remove
            return RedirectToAction("MyWishList", "Product");
        }

        public ActionResult LastestProducts(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            ViewBag.label = "Sản phẩm mới";
            var model = db.Products.Where(p => p.Actived == true).OrderByDescending(p => p.CreateDate).ToList();
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult BestSaleProducts(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            ViewBag.label = "Xu hướng thời trang 2016";
            var model = db.Products.Where(p => p.Actived == true).OrderByDescending(p => p.Views).ToList();
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ListBySpecial(string Id, int?page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            List<Product> model = null;
            switch (Id)
            {
                case "All":
                    model = db.Products.Where(p => p.Actived == true).ToList();
                    ViewBag.Id = Id;
                   
                    break;
                case "Latest":
                    model = db.Products.Where(p => p.Actived == true).OrderByDescending(p => p.CreateDate).ToList();
                    ViewBag.label = "Mới";
                  
                    break;
                case "Best":
                    model = db.Products.Where(p => p.Actived == true)
                        .Where(p => p.Views > 0)
                        .OrderByDescending(p => p.Views).ToList();
                    ViewBag.label = "Bán chạy";
                    break;
                case "Special":
                    model = db.Products.Where(p => p.Actived == true)
                        .Where(p => p.IsFeatured.Value).ToList();
                    ViewBag.label = Id;
                    break;
                case "SalesOff":
                    model = db.Products.Where(p => p.Actived == true)
                        .Where(p => p.Discount > 0)
                        .OrderByDescending(p => p.Discount).ToList();
                    ViewBag.label = Id;
                    break;
                case "Favorite":
                    model = db.Products.Where(p => p.Actived == true).ToList();
                    ViewBag.label = Id;
                    break;

                default:
                    model = db.Products.Where(p => p.Actived == true).ToList();
                        //.Where(p => p.ManufactId == Id).ToList();
                    ViewBag.label = Id;
                    break;
             }

            ViewBag.Id = Id;

            // return View(students.ToPagedList(pageNumber, pageSize));
            // return PartialView("Partials/_Search", model.ToPagedList(pageNumber, pageSize));
            return View("ProductList", model.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult _HeaderSearchForm()
        {
            return PartialView();
        }

        public ActionResult _FeaturedProducts()
        {
            var featuredProducts = db.Products.Where(p => p.IsFeatured.Value).OrderByDescending(p => p.Views).Take(5).ToList();
            return PartialView(featuredProducts);
        }

        public ActionResult _LastestProducts()
        {
            var lastestProducts = db.Products.OrderByDescending(p => p.CreateDate).Take(20).ToList();
            return PartialView(lastestProducts);
        }

        public ActionResult _BestSalerProducts()
        {
            var bestSalers = db.Products.OrderByDescending(p => p.Views).Take(5).ToList();
            return PartialView(bestSalers);
        }

        public ActionResult _DiscountProducts()
        {
            var DiscountProducts = db.Products.Where(p => p.Discount != null && p.Discount > 5).OrderByDescending(p => p.Discount).Take(5).ToList();
            return PartialView(DiscountProducts);
        }

        public ActionResult _Sidebar()
        {
            var productCategories = db.ProductCategories.Where(pc => pc.ParentId == null).ToList();
            return PartialView(productCategories);
        }

        public ActionResult _SidebarDetails()
        {
            return PartialView();
        }

        public ActionResult _relatedProduct(Product product)
        {
            //san pham cung chuyen muc
            var model = db.Products.Where(p => p.CatId == product.CatId && p.Id != product.Id && p.Actived.Value).Take(4).ToList();
            return PartialView(model);
        }

        public ActionResult _viewedProducts()
        {
            var list = Products;
            return PartialView(list.Take(10));
        }

        public ActionResult Special()
        {
            var model = db.Products.Where(p => p.Actived == true).Take(10);
            return PartialView("Partials/_Special", model);
        }


        //Download source code tại Sharecode.vn
        public ActionResult Saleoff()
        {
            var model = db.Products.Where(p => p.Actived == true).Where(p => p.Discount > 0).Take(5);
            return PartialView("Partials/_Saleoff", model);
        }

    }
}