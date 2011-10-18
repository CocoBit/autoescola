using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Models.Repositorios;
using AutoEscola.Models.Servicos.Interfaces;
using AutoEscola.Controllers;

namespace AutoEscola.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        private IServicosUsuarioAdmin ServicosUsuarioAdmin;

        public UsuarioController(IServicosUsuarioAdmin servicoUsuario)
        {
            this.ServicosUsuarioAdmin = servicoUsuario;
        }

        public ActionResult Create()
        {
            var usuario = new Usuario();
            usuario.Pessoa = new Pessoa();
            usuario.Pessoa.Empresa = new Empresa();
            return View(usuario);
        }

        [HttpPost]
        [HandleError]
        public ActionResult Create(Usuario usuario)
        {
            ServicosUsuarioAdmin.CriarContaDeUsuarioSuperAdminFree(usuario);

            if (ServicosUsuarioAdmin.ExisteErros())
            {
                foreach (string mensagem in ServicosUsuarioAdmin.Erros())
                    ModelState.AddModelError("", mensagem);
                return View(usuario);
            }

            EnviarEmail(usuario);

            return RedirectToAction("Confirmar", "Conta", new { area = "" });
        }

        private void EnviarEmail(Usuario usuario)
        {
            var email = new EmailController();
            email.VerificationEmail(usuario).Deliver();
        }

        [HttpPost]
        [HandleError]
        public ActionResult logar(FormCollection formulario)
        {
            var usuario = formulario["usuario"];
            var senha = formulario["senha"];

            if (ServicosUsuarioAdmin.Logar(usuario, senha))
                return RedirectToAction("HomeAdmin", "Index");
            if (ServicosUsuarioAdmin.LogarFreeTour(usuario, senha))
                return RedirectToAction("HomeAdmin", "Index");
            else
                return RedirectToAction("ErroLogin");
        }

        public ActionResult ErroLogin()
        {
            ViewBag.Login = "admin";
            foreach (string mensagem in ServicosUsuarioAdmin.Erros())
                ModelState.AddModelError("", mensagem);
            return View();
        }

        [HttpGet]
        public ActionResult Desconectar()
        {
            ServicosUsuarioAdmin.Desconectar();
            return RedirectToAction("Index", "Home");
        }

    }
}
