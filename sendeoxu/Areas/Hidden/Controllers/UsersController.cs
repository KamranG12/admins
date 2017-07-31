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
    public class UsersController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();

        // GET: Hidden/Users
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return View(db.Users.ToList());
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/Users/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                return View();
            }  
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fullname,email,password,profil_picture,bio")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Hidden/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullname,email,password,profil_picture,bio")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Hidden/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
