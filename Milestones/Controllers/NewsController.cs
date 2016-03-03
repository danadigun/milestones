using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Milestones.Models;
using Milestones.SupportClasses;

namespace Milestones.Controllers
{
    public class NewsController : Controller
    {
        private MilestoneDb db = new MilestoneDb();

        //
        // GET: /News/
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            //return View(db.LatestActivities.ToList());
            return Redirect("~/Home/news");
        }

        //
        // GET: /News/Details/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Details(int id, string title)
        {           
           
            //var latestactivities = from s in db.LatestActivities where s.id == id && s.title == title select s;
            //Product product = db.Products.Single(p => p.ProductID == id);
            LatestActivities latestactivities = db.LatestActivities.Single(p => p.id == id);

            if (latestactivities == null)
            {
                return HttpNotFound();
            }
        
            //make sure the title for the route matches ended title name
            string expectedTitle = latestactivities.title.ToSeoUrl();
            string actualTitle = (title ?? "").ToLower();

            //permanently redirect to the correct URL
            if (expectedTitle != actualTitle)
            {
                return RedirectPermanent("~/News/Details/" + latestactivities.id + "/" + expectedTitle);
            }
            return View(latestactivities);
        }

        //
        // GET: /News/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(LatestActivities latestactivities)
        {
            if (ModelState.IsValid)
            {
                db.LatestActivities.Add(latestactivities);
                db.SaveChanges();
                //return RedirectToAction("Index");
                //return Redirect("~/Home/admin");
                return RedirectToAction("Details/" + latestactivities.id);
            }

            return View(latestactivities);
        }

        //
        // GET: /News/Edit/5
        [Authorize(Roles = "Admin")]
        [ValidateInput(false)]
        public ActionResult Edit(int id = 0)
        {
            LatestActivities latestactivities = db.LatestActivities.Find(id);
            if (latestactivities == null)
            {
                return HttpNotFound();
            }
            return View(latestactivities);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles="Admin")]
        public ActionResult Edit(LatestActivities latestactivities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latestactivities).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                //return RedirectToAction("Details?id=" + latestactivities.id+"&title="+latestactivities.title);
                return Redirect("~/News/Details?id=" + latestactivities.id + "&title=" + latestactivities.title);
            }
            return View(latestactivities);
        }

        //
        // GET: /News/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            LatestActivities latestactivities = db.LatestActivities.Find(id);
            if (latestactivities == null)
            {
                return HttpNotFound();
            }
            return View(latestactivities);
        }

        //
        // POST: /News/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            LatestActivities latestactivities = db.LatestActivities.Find(id);
            db.LatestActivities.Remove(latestactivities);
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