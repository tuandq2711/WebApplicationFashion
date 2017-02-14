using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FashionGo.Models.Entities;
using FashionGo.Models;

namespace FashionGo.Areas.Admin.Controllers
{
    public class BannersController : AdminController
    {
        // GET: Admin/Banners
        public ActionResult Index()
        {
            var banners = db.Banners.Include(b => b.BannerType).Include(b => b.BannerPosition);
            return View(banners.ToList());
        }

        // GET: Admin/Banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: Admin/Banners/Create
        public ActionResult Create()
        {
            ViewBag.BannerTypeId = new SelectList(db.BannerTypes, "BannerTypeId", "Name");
            ViewBag.BannerPositionId = new SelectList(db.BannerPositions, "BannerPositionId", "Name");
            return View();
        }

        // POST: Admin/Banners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "BannerId,Name,BannerTypeId,BannerPositionId,Description,Content,StartDate,EndDate,Active")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Banners.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BannerTypeId = new SelectList(db.BannerTypes, "BannerTypeId", "Name", banner.BannerTypeId);
            ViewBag.BannerPositionId = new SelectList(db.BannerPositions, "BannerPositionId", "Name", banner.BannerPositionId);
            return View(banner);
        }

        // GET: Admin/Banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            ViewBag.BannerTypeId = new SelectList(db.BannerTypes, "BannerTypeId", "Name", banner.BannerTypeId);
            ViewBag.BannerPositionId = new SelectList(db.BannerPositions, "BannerPositionId", "Name", banner.BannerPositionId);
            return View(banner);
        }

        // POST: Admin/Banners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "BannerId,Name,BannerTypeId,BannerPositionId,Description,Content,StartDate,EndDate,Active")] Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BannerTypeId = new SelectList(db.BannerTypes, "BannerTypeId", "Name", banner.BannerTypeId);
            ViewBag.BannerPositionId = new SelectList(db.BannerPositions, "BannerPositionId", "Name", banner.BannerPositionId);
            return View(banner);
        }

        // GET: Admin/Banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banner banner = db.Banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Admin/Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Banner banner = db.Banners.Find(id);
            db.Banners.Remove(banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
