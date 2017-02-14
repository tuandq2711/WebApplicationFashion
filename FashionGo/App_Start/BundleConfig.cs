using System.Web;
using System.Web.Optimization;

namespace FashionGo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/BootstrapValidator/css").Include(
               "~/Scripts/BootstrapValidator/css/bootstrapValidator.min.css"
            ));
            bundles.Add(new ScriptBundle("~/BootstrapValidator/jquery").Include(
              "~/Scripts/BootstrapValidator/js/bootstrapValidator.min.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));



            bundles.Add(new StyleBundle("~/Assets/Frontend/FashionPro").Include(
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.bootstrap.less.css",
                    "~/Assets/Frontend/components/com_eshop/assets/bootstrap/css/bootstrap.css",
                    "~/Assets/Frontend/components/com_eshop/assets/bootstrap/css/bootstrap.min.css",
                    "~/Assets/Frontend/components/com_eshop/themes/fashionpro/css/style.css",
                    "~/Assets/Frontend/components/com_eshop/themes/fashionpro/css/custom.css",
                    "~/Assets/Frontend/components/com_eshop/assets/colorbox/colorbox.css",
                    "~/Assets/Frontend/components/com_eshop/assets/css/labels.css",
                    "~/Assets/Frontend/templates/system/css/system.css",
                    "~/Assets/Frontend/t3-assets/dev/red/plugins.system.t3.base-bs3.less.t3.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.core.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.typography.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.forms.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.navigation.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.navbar.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.modules.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.joomla.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.components.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.style.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.themes.red.template.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.template.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/plugins.system.t3.base-bs3.less.megamenu.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.megamenu.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/plugins.system.t3.base-bs3.less.off-canvas.less.css",
                    "~/Assets/Frontend/t3-assets/dev/red/templates.eshop_fashion_pro.less.off-canvas.less.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/fonts/font-awesome/css/font-awesome.min.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_oschangetemplatestyle.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_manufacturer.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_product.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_category.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_advanced_search.css",
                    "~/Assets/Frontend/modules/mod_eshop_advanced_search/assets/css/jquery.nouislider.css",

                    "~/Assets/Frontend/components/com_eshop/assets/colorbox/colorbox.css",
                    "~/Assets/Frontend/components/com_eshop/assets/css/labels.css",
                    "~/Assets/Frontend/components/com_eshop/themes/fashionpro/css/style.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_producttabs.css",
                    
                    "~/Assets/Frontend/modules/mod_os_testimonial/asset/css/style.css",
                    "~/Assets/Frontend/components/font-awesome/css/font-awesome.css",
                    "~/Assets/Frontend/modules/mod_os_testimonial/asset/vendor/bootstrap/css/testimonial.css",
                    "~/Assets/Frontend/modules/mod_sp_smart_slider/tmpl/awetive/css/awetive.slider.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_sp_smart_slider/tmpl/awetive.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_cart.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_search.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/html/mod_bt_login/css/style2.0.css",
                    "~/Assets/Frontend/templates/eshop_fashion_pro/css/mod_eshop_currency.css"
            ));

            bundles.Add(new StyleBundle("~/Content/style").Include(
                    "~/Content/PagedList.css",
                    "~/Content/select2.min.css",
                    "~/Content/contact-popup.css"
            ));



            bundles.Add(new ScriptBundle("~/Assets/Frontend/jquery").Include(
                       "~/Scripts/jquery-1.10.2.min.js",
                       //"~/Scripts/media/jui/js/jquery-noconflict.js",
                       "~/Scripts/media/jui/js/jquery-migrate.min.js",
                       "~/Scripts/plugins/system/t3/base-bs3/bootstrap/js/bootstrap.js",
                       //"~/Scripts/components/com_eshop/assets/js/noconflict.js",
                       "~/Scripts/components/com_eshop/assets/js/eshop.js",
                       "~/Scripts/plugins/system/t3/base-bs3/js/jquery.tap.min.js",
                       "~/Scripts/plugins/system/t3/base-bs3/js/off-canvas.js",
                       "~/Scripts/plugins/system/t3/base-bs3/js/script.js",
                       "~/Scripts/plugins/system/t3/base-bs3/js/menu.js",
                       "~/Scripts/plugins/system/t3/base-bs3/js/nav-collapse.js",
                       "~/Scripts/modules/mod_oschangetemplatestyle/asset/cpanel.js",
                       "~/Scripts/components/com_eshop/assets/js/slick.js",
                       "~/Scripts/modules/mod_eshop_product/assets/js/owl.carousel.js",
                       "~/Scripts/components/com_eshop/assets/colorbox/jquery.colorbox.js",
                       "~/Scripts/modules/mod_eshop_producttabs/assets/js/eshop-pagination.js",
                       "~/Scripts/modules/mod_sp_smart_slider/tmpl/awetive/js/sp-smart-slider.js",
                       "~/Scripts/templates/eshop_fashion_pro/html/mod_bt_login/js/jquery.simplemodal.js",
                       "~/Scripts/templates/eshop_fashion_pro/html/mod_bt_login/js/default.js",
                       "~/Scripts/media/system/js/core.js",
                       "~/Scripts/jquery.number.min.js",
                       "~/Scripts/FlyingCart.js",
                       "~/Scripts/app.js"
            ));
            bundles.Add(new ScriptBundle("~/Assets/FireBase").Include(
                "https://www.gstatic.com/firebasejs/3.6.9/firebase.js",
                "~/Assets/firebase/firebase_key.js"
            ));

        }
    }
}
