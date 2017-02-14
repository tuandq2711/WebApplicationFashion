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
    public class OrderStatusController : AdminController
    {

        // GET: Admin/OrderStatus
        public ActionResult Index()
        {
            return View(db.OrderStatus.ToList());
        }

        // GET: Admin/OrderStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            if (orderStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderStatus);
        }

        // GET: Admin/OrderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OrderStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Note")] OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                db.OrderStatus.Add(orderStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderStatus);
        }

        // GET: Admin/OrderStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            if (orderStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderStatus);
        }

        // POST: Admin/OrderStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Note")] OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderStatus);
        }

        // GET: Admin/OrderStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            if (orderStatus == null)
            {
                return HttpNotFound();
            }
            return View(orderStatus);
        }

        // POST: Admin/OrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderStatus orderStatus = db.OrderStatus.Find(id);
            db.OrderStatus.Remove(orderStatus);
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
