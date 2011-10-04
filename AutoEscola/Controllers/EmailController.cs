using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActionMailer.Net.Mvc;
using AutoEscola.Models;

namespace AutoEscola.Controllers
{
    public class EmailController : MailerBase
    {
        public EmailResult VerificationEmail(Usuario model)
        {
            To.Add(model.Email);
            From = "autoescolasimples@gmail.com";
            Subject = "Welcome to My Cool Site!";
            return Email("VerificationEmail", model);
        }
    }
}
