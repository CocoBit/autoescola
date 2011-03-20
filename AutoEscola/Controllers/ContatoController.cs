using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace AutoEscola.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EnviarEmail(string email, string assunto, string mensagem)
        {
            WebMail.SmtpServer = "mail.cocobit.com.br";
            WebMail.From = "cadastro@cocobit.com.br";
            WebMail.UserName = "cadastro@cocobit.com.brr";
            WebMail.Password = "brunoramonyan";
            WebMail.Send(email, assunto, mensagem);
            return RedirectToAction("Index", "Home");
        }

    }
}
