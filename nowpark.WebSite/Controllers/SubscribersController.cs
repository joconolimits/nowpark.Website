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
            //Block of code for manually adding subscribers in the database
//            string[] subscribers = new string[] {
//               "mishevivan@gmail.com",
                //"andrijana.djurovic@gmail.com",
                //"gokovet@hotmail.com",
                //"teddy@g6Solutions.com",
                //"dani.milosheska@gmail.com",
                //"ivanka_86@hotmail.com",
                //"risted@gmail.com",
                //"ilayd@me.com",
                //"slobodan.joveski@ivote.mk",
                //"stojanka88@hotmail.com",
                //"gpancic@gmail.com",
                //"stojankakoceva@gmail.com",
                //"aleksandar_vasiloski@hotmail.com",
                //"goce.stojcev@gmail.com",
                //"yanche@t-home.mk",
                //"anastasijadespotovska@hotmail.com",
                //"rizagfx@gmail.com",
                //"mitevz@gmail.com",
                //"Naumovska.angela@hotmail.com",
                //"damir@dash.ba",
                //"pepica_m@hotmail.com",
                //"zjankuloski51@gmail.com",
                //"plavjan@hotmail.com",
                //"miki84sk@gmail.com",
                //"atanasova.jasna@gmail.com",
                //"Todor.popovski@gmail.com",
                //"mvelkovski33@yahoo.ca",
                //"Nikola@e.com",
                //"markovski03@yahoo.com",
                //"elena.sekulovska86@gmail.com",
                //"martinovska_i@hotmail.com",
                //"peter.trapp@pioneers.io",
                //"nikola@ebusiness.com.mk"
                //};
//            foreach (var item in subscribers)
//            {
                
//                if (db.Subscribers.SingleOrDefault(x =>x.Email == item)==null)
//                {
//                    Subscriber subscriber = new Subscriber();   
//                    subscriber.Email = item;
//                    db.Subscribers.Add(subscriber);
//                    db.SaveChanges();
//                }
//            }
            
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
