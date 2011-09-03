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
            WebMail.SmtpServer = "";
            WebMail.From = "";
            WebMail.UserName = "";
            WebMail.Password = "";
            WebMail.Send(email, assunto, mensagem);
            return View();
        }
    }



}