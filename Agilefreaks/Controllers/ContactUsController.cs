using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Agilefreaks.Models;
using SendGridMail;
using SendGridMail.Transport;

namespace Agilefreaks.Controllers
{
    public class ContactUsController : Controller
    {
        private const string ContactEmail = "office@agilefreaks.com";

        [HttpPost]
        public ActionResult SendEmail(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                SendGrid message = SendGrid.GetInstance();
                message.From = new MailAddress(model.Email);
                message.Subject = model.Name;
                message.Text = model.Message;
                message.AddTo(ContactEmail);

                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["SendGridUsername"], ConfigurationManager.AppSettings["SendGridPassword"]);
                var transportSMTP = SMTP.GetInstance(credentials);

                transportSMTP.Deliver(message);
            }

            return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }) + "#" + "contact");
        }
    }
}