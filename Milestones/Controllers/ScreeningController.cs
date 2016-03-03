using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Milestones.Models;

namespace Milestones.Controllers
{
    public class ScreeningController : Controller
    {
        private MilestoneDb db = new MilestoneDb();

        //
        // GET: /Screening/
        [Authorize]
        public ActionResult Index()
        {            
            return View();
        }

        //
        // GET: /Screening/Details/5

        public ActionResult Details(int id = 0)
        {
            ScreeningTest screeningtest = db.ScreeningTests.Find(id);
            if (screeningtest == null)
            {
                return HttpNotFound();
            }
            return View(screeningtest);
        }

        //
        // GET: /Screening/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Screening/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ScreeningTest screeningtest)
        {
            if (ModelState.IsValid)
            {
                db.ScreeningTests.Add(screeningtest);

                //create a new record of questions answered by the user
                AnsweredQuestion question = new AnsweredQuestion
                {
                    username = User.Identity.Name.ToString(),
                    QuestionId = screeningtest.id,
                    DateCreated = DateTime.Now
                };
                db.AnsweredQuestions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(screeningtest);
        }
        //
        //GET: /Screening/ViewUserAssessment/?id=username
        public ActionResult ViewUserAssessment(string username)
        {
            var UserScreening = from s in db.ScreeningTests where s.username == username select s;

            return View(UserScreening.ToList());
        }
        //POST: /Screening/MarkAsRead?username= 
        public ActionResult MarkAsRead(string username)
        {
            ViewedAssessments assessment = new ViewedAssessments
            {
                username = username,
                DateViewed = DateTime.Now
            };
            db.ViewedAssessments.Add(assessment);
            db.SaveChanges();

            return Redirect("~/Home/ViewAssessments");
        }
        //
        // GET: /Screening/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ScreeningTest screeningtest = db.ScreeningTests.Find(id);
            if (screeningtest == null)
            {
                return HttpNotFound();
            }
            return View(screeningtest);
        }

        //
        // POST: /Screening/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScreeningTest screeningtest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screeningtest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(screeningtest);
        }

        //
        // GET: /Screening/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ScreeningTest screeningtest = db.ScreeningTests.Find(id);
            if (screeningtest == null)
            {
                return HttpNotFound();
            }
            return View(screeningtest);
        }

        //
        // POST: /Screening/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScreeningTest screeningtest = db.ScreeningTests.Find(id);
            db.ScreeningTests.Remove(screeningtest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}