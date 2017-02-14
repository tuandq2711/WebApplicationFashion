using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FashionGo.Models;
using FashionGo.Models.Entities;

namespace FashionGo.Areas.Admin.Controllers
{
    public class ManufactsController : AdminController
    {
        // GET: Admin/Manufacts
        public ActionResult Index()
        {
            return View(db.Manufacts.ToList());
        }

        // GET: Admin/Manufacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufact manufact = db.Manufacts.Find(id);
            if (manufact == null)
            {
                return HttpNotFound();
            }
            return View(manufact);
        }

        // GET: Admin/Manufacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Manufacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,logo,description")] Manufact manufact)
        {
            if (ModelState.IsValid)
            {
                db.Manufacts.Add(manufact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufact);
        }

        // GET: Admin/Manufacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufact manufact = db.Manufacts.Find(id);
            if (manufact == null)
            {
                return HttpNotFound();
            }
            return View(manufact);
        }

        // POST: Admin/Manufacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,logo,description")] Manufact manufact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufact);
        }

        // GET: Admin/Manufacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufact manufact = db.Manufacts.Find(id);
            if (manufact == null)
            {
                return HttpNotFound();
            }
            return View(manufact);
        }

        // POST: Admin/Manufacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufact manufact = db.Manufacts.Find(id);
            db.Manufacts.Remove(manufact);
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
