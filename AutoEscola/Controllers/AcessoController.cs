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
                    FormsAuthentication.Authenticate(usuario, senha);

                    var usuarioRepository = RepositoryFactory.CreateUsuarioRepository();
                    var usuario_sessao = usuarioRepository.FindByLoginAndPassWord(usuario, senha);

                    if (usuario_sessao == null)
                        ModelState.AddModelError("", "Usuário não localizado.");
                    else
                    {
                        Session["pessoa_sessao"] = usuario_sessao.Pessoa;
                        return RedirectToAction("Details", "Aluno", usuario_sessao.Pessoa.Id);
                    }
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

        [HttpGet]
        public ActionResult Desconectar()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Conectar", "Acesso");
        }
    }
}
