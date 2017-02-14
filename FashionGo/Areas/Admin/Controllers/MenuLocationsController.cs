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
    public class MenuLocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/MenuLocations
        public ActionResult Index()
        {
            return View(db.MenuLocations.ToList());
        }

        // GET: Admin/MenuLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuLocation menuLocation = db.MenuLocations.Find(id);
            if (menuLocation == null)
            {
                return HttpNotFound();
            }
            return View(menuLocation);
        }

        // GET: Admin/MenuLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MenuLocation menuLocation)
        {
            if (ModelState.IsValid)
            {
                db.MenuLocations.Add(menuLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuLocation);
        }

        // GET: Admin/MenuLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuLocation menuLocation = db.MenuLocations.Find(id);
            if (menuLocation == null)
            {
                return HttpNotFound();
            }
            return View(menuLocation);
        }

        // POST: Admin/MenuLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MenuLocation menuLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuLocation);
        }

        // GET: Admin/MenuLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuLocation menuLocation = db.MenuLocations.Find(id);
            if (menuLocation == null)
            {
                return HttpNotFound();
            }
            return View(menuLocation);
        }

        // POST: Admin/MenuLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuLocation menuLocation = db.MenuLocations.Find(id);
            db.MenuLocations.Remove(menuLocation);
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
