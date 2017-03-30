using System;
using System.Web.Mvc;
using Agilefreaks.Models;
using System.Threading.Tasks;
using PostmarkDotNet;


namespace Agilefreaks.Controllers
{
    public class ContactUsController : Controller
    {
        private const string ContactEmail = "office@agilefreaks.com";
        private const string SenderEmail = "office@agilefreaks.com";

        [HttpPost]
        public async Task<ActionResult> SendEmail(ContactUsModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Url.RouteUrl(new {controller = "Home", action = "Index"}) + "#" + "contact");
            }
            var message = CreateMessage(model);
            var apiKey = Environment.GetEnvironmentVariable("POSTMARK_APIKEY");

            await SendMailMessage(apiKey, message);

            return Redirect(Url.RouteUrl(new {controller = "Home", action = "Index"}) + "#" + "contact");
        }

        public PostmarkMessage CreateMessage(ContactUsModel model)
        {
            return new PostmarkMessage
            {
                To = ContactEmail,
                From = SenderEmail,
                Subject = model.Name,
                TextBody = model.Message,
                ReplyTo = model.Email
            };
        }
        
        public async Task<PostmarkStatus> SendMailMessage(string apiKey, PostmarkMessage message)
        {
            const string errorMessage = "Error on sending message. Please try again!";
            var sendStatus = PostmarkStatus.ServerError;

            try
            {
                var client = new PostmarkClient(apiKey);
                var sendResult = await client.SendMessageAsync(message);
                TempData["Notification"] = sendResult.Status == PostmarkStatus.Success ? "Message sent." : errorMessage;
                sendStatus = sendResult.Status;
            }
            catch
            {
                TempData["Notification"] = errorMessage;
            }

            return sendStatus;
        }
    }
}