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
    public class CommentsController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();

        // GET: Hidden/Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Source).Include(c => c.User);
            if (Session["admin"] != null)
            {
                return View(comments.ToList());
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(comment);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/Comments/Create
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

        // POST: Hidden/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,comment1,user_id,topic_id")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", comment.topic_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", comment.user_id);
            return View(comment);
        }

        // GET: Hidden/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", comment.topic_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", comment.user_id);
            if (Session["admin"] != null)
            {
                return View(comment);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,comment1,user_id,topic_id")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", comment.topic_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "fullname", comment.user_id);
            return View(comment);
        }

        // GET: Hidden/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(comment);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }

        }

        // POST: Hidden/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
