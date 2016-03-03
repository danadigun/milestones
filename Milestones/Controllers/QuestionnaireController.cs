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
    public class QuestionnaireController : Controller
    {
        private MilestoneDb db = new MilestoneDb();

        //
        // GET: /Questionnaire/

        public ActionResult Index()
        {
            return View(db.Questionnaires.ToList());
        }

        //
        // GET: /Questionnaire/Details/5

        public ActionResult Details(int id = 0)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        //
        // GET: /Questionnaire/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Questionnaire/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Questionnaires.Add(questionnaire);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect("~/Home/admin");
            }

            return View(questionnaire);
        }

        //
        // GET: /Questionnaire/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        //
        // POST: /Questionnaire/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionnaire);
        }

        //
        // GET: /Questionnaire/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        //
        // POST: /Questionnaire/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questionnaire questionnaire = db.Questionnaires.Find(id);
            db.Questionnaires.Remove(questionnaire);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect("~/Home/admin");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}