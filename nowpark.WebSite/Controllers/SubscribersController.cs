using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nowpark.WebSite.Models;

namespace nowpark.WebSite.Controllers
{
    public class SubscribersController : Controller
    {
        private nowparkDbEntities db = new nowparkDbEntities();

        // GET: Subscribers
        public ActionResult Index()
        {
            return View(db.Subscribers);
        }

        // GET: Subscribers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // GET: Subscribers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,SubscriptionDate")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Subscribers.Add(subscriber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subscriber);
        }

        // GET: Subscribers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,SubscriptionDate")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscriber);
        }

        // GET: Subscribers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Subscriber subscriber = db.Subscribers.Find(id);
            db.Subscribers.Remove(subscriber);
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
