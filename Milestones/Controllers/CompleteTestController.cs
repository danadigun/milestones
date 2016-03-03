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
    public class CompleteTestController : Controller
    {
        private MilestoneDb db = new MilestoneDb();

        //
        // GET: /CompleteTest/

        public ActionResult Index()
        {
            return View(db.CompletedQuetionnaires.ToList());
        }

        //
        // GET: /CompleteTest/Details/5

        public ActionResult Details(int id = 0)
        {
            CompletedQuestionnaire completedquestionnaire = db.CompletedQuetionnaires.Find(id);
            if (completedquestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(completedquestionnaire);
        }

        //
        // GET: /CompleteTest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CompleteTest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompletedQuestionnaire completedquestionnaire)
        {
            if (ModelState.IsValid)
            {
                db.CompletedQuetionnaires.Add(completedquestionnaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(completedquestionnaire);
        }

        //
        // GET: /CompleteTest/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CompletedQuestionnaire completedquestionnaire = db.CompletedQuetionnaires.Find(id);
            if (completedquestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(completedquestionnaire);
        }

        //
        // POST: /CompleteTest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompletedQuestionnaire completedquestionnaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(completedquestionnaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(completedquestionnaire);
        }

        //
        // GET: /CompleteTest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CompletedQuestionnaire completedquestionnaire = db.CompletedQuetionnaires.Find(id);
            if (completedquestionnaire == null)
            {
                return HttpNotFound();
            }
            return View(completedquestionnaire);
        }

        //
        // POST: /CompleteTest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompletedQuestionnaire completedquestionnaire = db.CompletedQuetionnaires.Find(id);
            db.CompletedQuetionnaires.Remove(completedquestionnaire);
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