using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionGo.Controllers
{
    public class BlogsController : BaseController
    {
        
        // GET: Blogs
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var pageSize = 8;
            var model = db.Posts.Where(p => p.Active == true).OrderByDescending(p => p.createDate).ToList();
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        

        // GET: Category
        public ActionResult Category(string Slug, int? page)
        {
            int pageNumber = (page ?? 1);
            var pageSize = 8;

            var Cat = db.Categories.SingleOrDefault(c => c.Slug == Slug);
            if (Cat == null)
            {
                return RedirectToRoute("404");
            }

            var model = Cat.Posts.OrderByDescending(p => p.createDate).Where(p => p.Active == true).ToList();
            ViewBag.Cat = Cat;
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ShowPost(string Slug)
        {
            var Post = db.Posts.SingleOrDefault(p => p.Slug == Slug);

            if (Post == null)
            {
                return RedirectToRoute("404");
            }

            ViewBag.RelatedPosts = db.Posts.Where(p => p.CatId == Post.CatId).Where(p => p.Id != Post.Id).Take(4).ToList();
            ViewBag.Cat = Post.Category;

            return View(Post);
        }

        //get siderbar
        public ActionResult _Sidebar()
        {
            ViewBag.Cats = db.Categories.ToList();
            var PopularPosts = db.Posts.OrderByDescending(p => p.createDate).Where(p => p.Active == true).Take(5);
            return PartialView(PopularPosts);
        }

        public ActionResult _LastNews()
        {
            var model = db.Posts.Where(p => p.Active == true).OrderByDescending(p => p.Id).Take(3);
            return PartialView(model);
        }
    }
}