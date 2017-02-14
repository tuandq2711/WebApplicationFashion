using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FashionGo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Product
            routes.MapRoute(name: "ProductCategory", url: "danh-muc/{slug}-{id}", defaults: new { controller = "Product", action = "ProductCategory", id = UrlParameter.Optional },namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "ProductDetails", url: "san-pham/{slug}-{id}", defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "SearchProduct", url: "tim-kiem-san-pham", defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },namespaces: new[] { "FashionGo.Controllers" } );
            routes.MapRoute(name: "AddProductFavorite", url: "danh-dau-yeu-thich/{id}", defaults: new { controller = "Product", action = "AddToWishList", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" } );
            routes.MapRoute(name: "ProductFavorite", url: "san-pham-yeu-thich", defaults: new { controller = "Product", action = "MyWishList", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "LastestProduct", url: "san-pham-moi", defaults: new { controller = "Product", action = "LastestProducts", Id = "Latest" }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "BestSalerProduct", url: "xu-huong-thoi-trang-2016", defaults: new { controller = "Product", action = "BestSaleProducts", Id = "Best" },namespaces: new[] { "FashionGo.Controllers" });


            //ShoppingCart
            routes.MapRoute(name: "ShopingCart", url: "gio-hang", defaults: new { controller = "Cart", action = "Index", Id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });

            //Order
            routes.MapRoute(name: "Checkout", url: "dat-hang", defaults: new { controller = "Order", action = "Checkout", Id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });

            //Blog
            routes.MapRoute(name: "BlogDetails", url: "bai-viet/{catslug}/{slug}", defaults: new { controller = "Blogs", action = "ShowPost", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "BlogCategory", url: "chuyen-muc/{slug}", defaults: new { controller = "Blogs", action = "Category", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "Blog", url: "bai-viet", defaults: new { controller = "Blogs", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });

            //Account
            routes.MapRoute(name: "AccountLogin", url: "Account/Login", defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "AccountRegister", url: "Account/Register", defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "ForgotPassword", url: "Account/Loss-password", defaults: new { controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute(name: "AccountManage", url: "Manage/{action}/{id}", defaults: new { controller = "Manage", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });

            //Page
            routes.MapRoute(name: "PageDetails", url: "{Slug}", defaults: new { controller = "Pages", action = "Index", id = UrlParameter.Optional },namespaces: new[] { "FashionGo.Controllers" });

            routes.MapRoute(name: "Home", url: "", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
            routes.MapRoute( name: "404", url: "{*url}", defaults: new { controller = "Home", action = "NotFound", id = UrlParameter.Optional }, namespaces: new[] { "FashionGo.Controllers" });
        }
    }
}
