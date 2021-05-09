using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.Services;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;

        public ContactController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }


        [HttpGet]
        public IActionResult Form()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Form(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {

                var messageEmail = $@"{model.Message} {Environment.NewLine} Email: {model.Email} {Environment.NewLine} Username: {model.Name}";

                Message message = new Message(new String[] { "lukasz.neumann90@gmail.com" }, model.Subject, messageEmail);

                _emailSender.SendEmail(message);

                ViewBag.UserMessage = "Message was sent.";
                ModelState.Clear();

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email not sent.");
            }


            return View();
        }

    }
}
