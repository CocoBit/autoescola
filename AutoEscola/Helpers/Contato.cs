using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace AutoEscola.Helpers
{
    public class Contato: Controller
    {
        [HttpPost]
        public ActionResult Enviar(string nome, string email, string assunto, string mensagem)
        {
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.From = "yanlimaj@gmail.com";
            WebMail.UserName = "yanlimaj@gmail.com";
            WebMail.Password = "ty210107myx5004";
            WebMail.Send(email, assunto, mensagem);
            return View();
        }
    }



}