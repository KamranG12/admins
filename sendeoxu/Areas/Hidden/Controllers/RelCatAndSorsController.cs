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
    public class RelCatAndSorsController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();

        // GET: Hidden/RelCatAndSors
        public ActionResult Index()
        {
            var relCatAndSors = db.RelCatAndSors.Include(r => r.Category).Include(r => r.Source);
            if (Session["admin"] != null)
            {
                return View(relCatAndSors.ToList());
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/RelCatAndSors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelCatAndSor relCatAndSor = db.RelCatAndSors.Find(id);
            if (relCatAndSor == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(relCatAndSor);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // GET: Hidden/RelCatAndSors/Create
        public ActionResult Create()
        {
            ViewBag.kateqoriya_id = new SelectList(db.Categories, "id", "kateqoriya_name");
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title");
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/RelCatAndSors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kateqoriya_id,topic_id")] RelCatAndSor relCatAndSor)
        {
            if (ModelState.IsValid)
            {
                db.RelCatAndSors.Add(relCatAndSor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kateqoriya_id = new SelectList(db.Categories, "id", "kateqoriya_name", relCatAndSor.kateqoriya_id);
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", relCatAndSor.topic_id);
            return View(relCatAndSor);
        }

        // GET: Hidden/RelCatAndSors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelCatAndSor relCatAndSor = db.RelCatAndSors.Find(id);
            if (relCatAndSor == null)
            {
                return HttpNotFound();
            }
            ViewBag.kateqoriya_id = new SelectList(db.Categories, "id", "kateqoriya_name", relCatAndSor.kateqoriya_id);
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", relCatAndSor.topic_id);
            if (Session["admin"] != null)
            {
                return View(relCatAndSor);
            }
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/RelCatAndSors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kateqoriya_id,topic_id")] RelCatAndSor relCatAndSor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relCatAndSor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kateqoriya_id = new SelectList(db.Categories, "id", "kateqoriya_name", relCatAndSor.kateqoriya_id);
            ViewBag.topic_id = new SelectList(db.Sources, "id", "title", relCatAndSor.topic_id);
            return View(relCatAndSor);
        }

        // GET: Hidden/RelCatAndSors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelCatAndSor relCatAndSor = db.RelCatAndSors.Find(id);
            if (relCatAndSor == null)
            {
                return HttpNotFound();
            }
            if (Session["admin"] != null)
            {
                return View(relCatAndSor);
            }    
            else
            {
                return RedirectToAction("login", "admin");
            }
        }

        // POST: Hidden/RelCatAndSors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelCatAndSor relCatAndSor = db.RelCatAndSors.Find(id);
            db.RelCatAndSors.Remove(relCatAndSor);
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
