using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionGo.Controllers
{
    public class BannerAdsController : Controller
    {
        // GET: BannerAds
        public ActionResult _HomeBanner()
        {
            return PartialView();
        }
    }
}