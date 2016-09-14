using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Test.Models
{
    public class NumberOfClicksController : Controller
    {
        private ClickDatabaseEntities db = new ClickDatabaseEntities();

        // GET: NumberOfClicks
        public ActionResult Index()
        {
            return View(db.NumberOfClicks.ToList());
        }

        // GET: NumberOfClicks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumberOfClick numberOfClick = db.NumberOfClicks.Find(id);
            if (numberOfClick == null)
            {
                return HttpNotFound();
            }
            return View(numberOfClick);
        }

        // GET: NumberOfClicks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NumberOfClicks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Counter")] NumberOfClick numberOfClick)
        {
            if (ModelState.IsValid)
            {
                db.NumberOfClicks.Add(numberOfClick);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(numberOfClick);
        }

        // GET: NumberOfClicks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumberOfClick numberOfClick = db.NumberOfClicks.Find(id);
            if (numberOfClick == null)
            {
                return HttpNotFound();
            }
            return View(numberOfClick);
        }

        // POST: NumberOfClicks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Counter")] NumberOfClick numberOfClick)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numberOfClick).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(numberOfClick);
        }

        // GET: NumberOfClicks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NumberOfClick numberOfClick = db.NumberOfClicks.Find(id);
            if (numberOfClick == null)
            {
                return HttpNotFound();
            }
            return View(numberOfClick);
        }

        // POST: NumberOfClicks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NumberOfClick numberOfClick = db.NumberOfClicks.Find(id);
            db.NumberOfClicks.Remove(numberOfClick);
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
