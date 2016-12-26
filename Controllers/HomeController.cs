using Svm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Svm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        shimlaEntities db = new shimlaEntities();
        public ActionResult Index()
        {
            return View(new RegisterSchoolModel());
        }
        [HttpPost]
        public ActionResult Index(RegisterSchoolModel ddlListPostData)
        {

            try
            {
                string value1 = Request["clientID"];
                //string value2 = Request["clientText"];          
                string schhoNaam = string.Empty;
                var userCount = db.tb_schoolregisetr.Single(u => u.school_code == value1);
                if (User != null)
                {
                    return Json(new { success = true, tbSchool = userCount.school_name, schoolCode = value1 });
                }
                return Json(new { success = false });
            }
            catch (Exception ex)
            {
                return View(new RegisterSchoolModel());
            }

        }
        [HttpPost]
        public ActionResult Register(RegisterSchoolModel obj, [Bind(Include = "user_name,user_role,school_code,approve_status,PhoneNo,isActive")]tb_login log)
        {
            if (ModelState.IsValid)
            {
                string uname = log.user_name;
                string code = log.school_code;
                //var count = db.tb_login.Single(u => u.user_name == uname && u.school_code == code);
                int count = db.tb_login.Count(u => u.user_name == uname && u.school_code == code);
                if (count == 0)
                {
                    db.tb_login.Add(log);
                    db.SaveChanges();
                    ModelState.Clear();
                    TempData["Success"] = "Registration Request Sent!";
                }
                else
                {
                    TempData["Count"] = "Already Registered!";
                }
                return View("Index", new RegisterSchoolModel());
            }
            return View("Index", new RegisterSchoolModel());

        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(LoginModel obj)
        {
            int Role = 1;
            return GetLoginStatus(obj, Role);        
        }
        public ActionResult Bhandhar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bhandhar(LoginModel obj)
        {
            int Role = 2;
            return GetLoginStatus(obj, Role);
        }

        private ActionResult GetLoginStatus(LoginModel obj, int Role)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    int count = db.tb_login.Count(u => u.user_name == obj.user_name && u.user_pwd == obj.user_pwd && u.user_role == Role && u.approve_status == "Approved" && u.isActive == 1);
                    if (count > 0)
                    {
                        var usr = db.tb_login.Single(u => u.user_name == obj.user_name && u.user_pwd == obj.user_pwd && u.user_role == Role && u.approve_status == "Approved" && u.isActive == 1);
                        if (usr != null)
                        {
                            Session["UserId"] = Convert.ToString(usr.user_name);
                            Session["UserRole"] = Convert.ToString(usr.user_role);
                            ModelState.Clear();
                            return RedirectToAction("Index", "Dashboard");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Login Attempt.");

                    }
                }               
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something went Wrong.Please Try Again.!");
            }
            return View();
        }

        public ActionResult School()
        {
            return View();
        }
        [HttpPost]
        public ActionResult School(LoginModel obj)
        {
            int Role = 3;
            return GetLoginStatus(obj, Role);
        }

        public ActionResult Sankul()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sankul(LoginModel obj)
        {
            int Role = 4;
            return GetLoginStatus(obj, Role);
        }
        public ActionResult Pariksha()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pariksha(LoginModel obj)
        {
            int Role = 5;
            return GetLoginStatus(obj, Role);
        }
        public ActionResult khelkood()
        {
            return View();
        }
        [HttpPost]
        public ActionResult khelkood(LoginModel obj)
        {
            int Role = 6;
            return GetLoginStatus(obj, Role);
        }
        public ActionResult Teacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Teacher(LoginModel obj)
        {
            int Role = 7;
            return GetLoginStatus(obj, Role);
        }
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student(LoginModel obj)
        {
            int Role = 8;
            return GetLoginStatus(obj, Role);
        }
        public ActionResult Parents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Parents(LoginModel obj)
        {
            int Role = 9;
            return GetLoginStatus(obj, Role);
        }

    }


}