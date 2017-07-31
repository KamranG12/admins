using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;

namespace sendeoxu.Areas.Hidden.Controllers
{
    public class ReviewsController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();

        // GET: Hidden/Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Source).Include(r => r.User);
            if (Session["admin"] != null)
            {
                return View(reviews.ToList());
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(review);
            } 
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/Reviews/Create
        public ActionResult Create()
        {
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title");
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname");
            if (Session["admin"] != null)
            {
                return View();
            }  
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,like_count,dislike_count,user_id,topic_id")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", review.topic_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", review.user_id);
            return View(review);
        }

        // GET: Hidden/Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", review.topic_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", review.user_id);
            if (Session["admin"] != null)
            {
                return View(review);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,like_count,dislike_count,user_id,topic_id")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", review.topic_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", review.user_id);
            return View(review);
        }

        // GET: Hidden/Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(review);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
