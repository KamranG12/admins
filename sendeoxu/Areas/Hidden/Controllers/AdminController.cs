using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sendeoxu.Models;

namespace sendeoxu.Areas.Hidden.Controllers
{
    public class AdminController : Controller
    {
        private FirstProjectEntities db = new FirstProjectEntities();
        // GET: Hidden/Admin
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin adm)
        {
            if (adm.username != null && adm.password != null)
            {
                Admin admin = db.Admins.FirstOrDefault(a => a.username == adm.username && a.password == adm.password);
                if (admin != null)
                {
                    Session["admin"] = true;
                    return RedirectToAction("index", "admin");
                }
                else
                {
                    Session["error_input"] = "Username ve ya password yalnisdir";
                    return RedirectToAction("login");
                }
            }
            else
            {
                Session["error_message"] = "Bosluq buraxma";
                return RedirectToAction("login");
            }

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login");
        }
    }
}