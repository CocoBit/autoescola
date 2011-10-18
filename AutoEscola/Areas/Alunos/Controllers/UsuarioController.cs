using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Controllers;
using AutoEscola.Models.Repositorios;
using AutoEscola.Models.Servicos.Interfaces;
using AutoEscola.Models.Servicos;

namespace AutoEscola.Areas.Alunos.Controllers
{
    public class UsuarioController : Controller
    {
        private IServicosUsuarioAluno ServicosUsuarioAluno;

        public UsuarioController(IServicosUsuarioAluno servicoUsuario)
        {
            this.ServicosUsuarioAluno = servicoUsuario;
        }

        public ActionResult Create()
        {

            var usuario = new Usuario();
            usuario.Pessoa = new Pessoa();
            return View(usuario);
        }

        [HttpPost]
        [HandleError]
        public ActionResult Create(Usuario usuario)
        {
            ServicosUsuarioAluno.CriarContaDeUsuarioAluno(usuario);

            if (ServicosUsuarioAluno.ExisteErros())
            {
                foreach (string mensagem in ServicosUsuarioAluno.Erros())
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

            if (ServicosUsuarioAluno.Logar(usuario, senha))
                return RedirectToAction("Detalhes", "Ocorrencias");
            else
                return RedirectToAction("ErrorLogin");
        }

        public ActionResult ErrorLogin()
        {
            ViewBag.Login = "aluno";
            foreach (string mensagem in ServicosUsuarioAluno.Erros())
                ModelState.AddModelError("", mensagem);

            return View();
        }

        [HttpGet]
        public ActionResult Desconectar()
        {
            ServicosUsuarioAluno.Desconectar();
            return RedirectToAction("Index", "Home");
        }

    }
}
