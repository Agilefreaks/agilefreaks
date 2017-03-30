using System.Threading.Tasks;
using Agilefreaks.Controllers;
using Agilefreaks.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostmarkDotNet;

namespace Agilefreaks.Tests
{
    [TestClass]
    public class ContactUsControllerTest
    {
        private PostmarkMessage _postmarkMessage;
        private ContactUsModel _contactUsModel;
        private ContactUsController _contactUsController;

        [TestInitialize]
        public void SetUp()
        {
            _contactUsController = new ContactUsController();
            _postmarkMessage = new PostmarkMessage
            {
                To = "office@agilefreaks.com",
                From = "office@agilefreaks.com",
                Subject = "A jobless man",
                TextBody = "Hire me!",
                ReplyTo = "test@test.com"
            };
        }

        [TestMethod]
        public void TestCreateMessage()
        {
            _contactUsModel = new ContactUsModel
            {
                Email = "test@test.com",
                Message = "Hire me!",
                Name = "A jobless man"
            };

            var result = _contactUsController.CreateMessage(_contactUsModel);

            Assert.AreSame(_postmarkMessage.To, result.To);
            Assert.AreSame(_postmarkMessage.From, result.From);
            Assert.AreSame(_postmarkMessage.Subject, result.Subject);
            Assert.AreSame(_postmarkMessage.TextBody, result.TextBody);
        }

        [TestMethod]
        public async Task TestSendMailMessage()
        {
            var result = await _contactUsController.SendMailMessage("POSTMARK_API_TEST", _postmarkMessage);

            Assert.AreEqual(PostmarkStatus.Success, result);
        }
    }
}