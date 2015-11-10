using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using nowpark.WebSite.Models;
using System.IO;
using System.Net.Mail;

namespace nowpark.WebSite.Controllers
{
    public class HomeController : Controller
    {

        private nowparkDbEntities db = new nowparkDbEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Subscribe(string email)
        {
            if (db.Subscribers.SingleOrDefault(x => x.Email == email) != null)
            {
                return Json("False", JsonRequestBehavior.AllowGet); ;
            }
            db.Subscribers.Add(new Subscriber() { Email = email, SubscriptionDate = DateTime.UtcNow});
            try
            {
                db.SaveChanges();
                string body;
                using (var sr = new StreamReader(Server.MapPath("\\Content\\template\\") + "template.htm"))
                {
                    body = sr.ReadToEnd();
                }
                try
                {
                    SmtpClient client = new SmtpClient();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential("contact@nowpark.me", "ninja");
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("contact@nowpark.me");
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = "Welcome:)";
                    mailMessage.Body = body;
                    mailMessage.To.Add(email);
                    client.Send(mailMessage);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                return Json("True", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }
        }
    }
}