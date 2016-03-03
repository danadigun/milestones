using Milestones.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Milestones.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

      
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Location()
        {
            return View();
        }
        public ActionResult News(){
            return View();
        }
        [Authorize]
        public ActionResult ScreeningTest()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult ViewAssessments()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewAllUsers()
        {
            return View();
        }
       

    }
}
