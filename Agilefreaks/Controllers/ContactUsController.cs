using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Agilefreaks.Models;

namespace Agilefreaks.Controllers
{
    using System.Threading.Tasks;

    using SendGrid;

    public class ContactUsController : Controller
    {
        private const string ContactEmail = "office@agilefreaks.com";

        [HttpPost]
        public async Task<ActionResult> SendEmail(ContactUsModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }) + "#" + "contact");
            }

            var message = new SendGridMessage
                              {
                                  From = new MailAddress(model.Email),
                                  Subject = model.Name,
                                  Text = model.Message
                              };
            message.AddTo(ContactEmail);
            var notificationMessage = "Message sent.";

            try
            {
                var credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["SendGridUsername"],
                    ConfigurationManager.AppSettings["SendGridPassword"]);
               var transportWeb = new Web(credentials);
               await transportWeb.DeliverAsync(message);
            }
            catch (Exception)
            {
                notificationMessage = "Error on sending message. Please try again!";
            }

            TempData["Notification"] = notificationMessage;

            return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }) + "#" + "contact");
        }
    }
}