using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Agilefreaks.Models;
using System.Threading.Tasks;


namespace Agilefreaks.Controllers
{
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

            return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }) + "#" + "contact");
        }
    }
}