using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Milestones.Models;
using System.Net.Mail;
using System.Net;

namespace Milestones.Controllers
{
    public class FeedBackController : Controller
    {
        private MilestoneDb db = new MilestoneDb();

        //
        // GET: /FeedBack/

        public ActionResult Index()
        {
            return View(db.FeedBacks.ToList());
        }

        //
        // GET: /FeedBack/Details/5

        public ActionResult Details(int id = 0)
        {
            FeedBack feedback = db.FeedBacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        //
        // GET: /FeedBack/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FeedBack/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                db.FeedBacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        //
        // GET: /FeedBack/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FeedBack feedback = db.FeedBacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        //
        // POST: /FeedBack/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        //
        // GET: /FeedBack/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FeedBack feedback = db.FeedBacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        //
        // POST: /FeedBack/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedBack feedback = db.FeedBacks.Find(id);
            db.FeedBacks.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult SendFeedBack(FeedBack feedback)
        //{
        //    string Text = "<html> <head> </head>" +
        //    " <body style= \" font-size:12px; font-family: Arial\">" +
        //    feedback.Message +
        //    "</body></html>";

        //    SendEmail("tayna-anita@mail.ru", Text);
        //    FeedBack tempForm = new FeedBack();
        //    return View(tempForm);
        //}


        //public static bool SendEmail(string SentTo, string Text)
        //{
        //    MailMessage msg = new MailMessage();

        //    msg.From = new MailAddress("Test@mail.ru");
        //    msg.To.Add(SentTo);
        //    msg.Subject = "Password";
        //    msg.Body = Text;
        //    msg.Priority = MailPriority.High;
        //    msg.IsBodyHtml = true;

        //    SmtpClient client = new SmtpClient("smtp.mail.ru", 25);



        //    client.UseDefaultCredentials = false;
        //    client.EnableSsl = false;
        //    client.Credentials = new NetworkCredential("TestLogin", "TestPassword");
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    //client.EnableSsl = true;

        //    try
        //    {
        //        client.Send(msg);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}