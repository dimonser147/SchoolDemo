using SchoolDemo.Business.Account;
using SchoolDemo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolDemo.Controllers
{
    [SchoolAuthorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return !Request.IsAuthenticated ? RedirectToAction("Login", "Account") : RedirectToAction("Parents");
        }

        public ActionResult Teachers()
        {
            ViewBag.Message = "Page is available only for teachers.";

            return View();
        }

        public ActionResult Students()
        {
            ViewBag.Message = "Page is available only for students.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Parents()
        {
            ViewBag.Message = "Page is public";

            return View();
        }
    }
}