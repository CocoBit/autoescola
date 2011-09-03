using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoEscola.Controllers
{
    public class MensagemController : Controller
    {
        //
        // GET: /Mensagem/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(string mensagem, string detalhe)
        {
            ViewBag.Mensagem = mensagem;
            ViewBag.Detalhe = detalhe;
            return View();
        }
    }
}
