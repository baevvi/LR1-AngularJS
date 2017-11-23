using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITDAngularJS.Models;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITDAngularJS.Controllers
{
    public class ContactController : Controller
    {

        readonly IOptions<EmailProperties> _emailProperties;

        public ContactController(IOptions<EmailProperties> emailProperties)
        {
            _emailProperties = emailProperties;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(
                        contactModel.Email, 
                        contactModel.Subject, 
                        contactModel.Message,
                        _emailProperties.Value.ContactEmail, 
                        _emailProperties.Value.ContactPassword, 
                        int.Parse(_emailProperties.Value.SmtpPort),
                        _emailProperties.Value.SmtpServer);

                    TempData["result"] = "Message sent.";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["result"] = @"Error: " + e.Message;
                }
            }
            return RedirectToAction("Index");
        }

    }
}
