using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoEscola.Repository;
using AutoEscola.Repository.Factory;

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
            try
            {
                string usuario = dadosForm["usuario"];
                string senha = dadosForm["senha"];

                if (Membership.Provider.ValidateUser(usuario, senha))
                {
                    FormsAuthentication.SetAuthCookie(usuario, false);

                    var usuarioRepository = RepositoryFactory.CreateUsuarioRepository();
                    usuarioRepository.FindByLoginAndPassWord(usuario, senha);

                    var usuarioDaSessao = 
                    return Redirect(url);
                }
                else
                {
                    ModelState.AddModelError("", "Usuário ou senha inválido.");
                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao autenticar usuario: " + ex.Message);
                return View();
            }
        }

        public ActionResult Desconectar()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
