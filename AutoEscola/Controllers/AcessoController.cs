using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AutoEscola.Controllers
{
    public class AcessoController : Controller
    {
        [HttpGet]
        public ActionResult Conectar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Conectar(FormCollection dadosForm, string url)
        {
            string usuario = dadosForm["usuario"];
            string senha = dadosForm["senha"];

            if (Membership.Provider.ValidateUser(usuario, senha))
            {
                FormsAuthentication.SetAuthCookie(usuario, false);
                return Redirect(url);
            }
            else
            {
                ModelState.AddModelError("", "Usuário ou senha inválido.");
            }

            return View();
        }

        public ActionResult Desconectar()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
