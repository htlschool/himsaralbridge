using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Svm.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if(Session["UserId"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
        public ActionResult Logout()
        {

            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();

            Session["UserId"] = null;
            Session["UserRole"] = null;
            return RedirectToAction("Index", "Home");

        }
    }
}