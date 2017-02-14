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
    public class TransportTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TransportTypes
        public ActionResult Index()
        {
            return View(db.TransportTypes.ToList());
        }

        // GET: Admin/TransportTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FashionGo.Models.Entities.TransportType transportType = db.TransportTypes.Find(id);
            if (transportType == null)
            {
                return HttpNotFound();
            }
            return View(transportType);
        }

        // GET: Admin/TransportTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TransportTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] FashionGo.Models.Entities.TransportType transportType)
        {
            if (ModelState.IsValid)
            {
                db.TransportTypes.Add(transportType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transportType);
        }

        // GET: Admin/TransportTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FashionGo.Models.Entities.TransportType transportType = db.TransportTypes.Find(id);
            if (transportType == null)
            {
                return HttpNotFound();
            }
            return View(transportType);
        }

        // POST: Admin/TransportTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] FashionGo.Models.Entities.TransportType transportType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transportType);
        }

        // GET: Admin/TransportTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FashionGo.Models.Entities.TransportType transportType = db.TransportTypes.Find(id);
            if (transportType == null)
            {
                return HttpNotFound();
            }
            return View(transportType);
        }

        // POST: Admin/TransportTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FashionGo.Models.Entities.TransportType transportType = db.TransportTypes.Find(id);
            db.TransportTypes.Remove(transportType);
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
