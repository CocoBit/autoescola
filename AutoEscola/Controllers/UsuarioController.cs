using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;
using AutoEscola.Contexts.Models;
using System.Web.Helpers;

namespace AutoEscola.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        IUsuarioRepository usuarioRepository;
        IRepository<Empresa> empresaRepository;
        IPessoaRepository pessoaRepository;

        public UsuarioController()
        {
            usuarioRepository = RepositoryFactory.CreateUsuarioRepository();
            empresaRepository = RepositoryFactory.CreateEmpresaRepository();
            pessoaRepository = RepositoryFactory.CreatePessoaRepository();

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string login, string senha)
        {
            var usuario = usuarioRepository.FindByLoginAndPassWord(login, senha);
            if (usuario != null)
                Session["Usuario"] = usuario;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            var usuario = new Usuario();
            usuario.Pessoa = new Pessoa();
            return View(usuario);
        }


        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            var pessoa = pessoaRepository.FindByCpf(usuario.Pessoa.CPF);
            if (pessoa == null)
            {
                ViewBag.Message = "Não foi identificado cadastro liberado para este CPF";
                return View(usuario);
            }

            usuario.Pessoa = pessoa;
            usuario.GerarChaveDeAtivacao();
            usuarioRepository.Create(usuario);
            EnviarEmail(usuario);
            return RedirectToAction("Index", "Home");
        }

        private void EnviarEmail(Usuario usuario)
        {
            WebMail.SmtpServer = "mail.cocobit.com.br";
            WebMail.From = "cadastro@cocobit.com.br";
            WebMail.UserName = "cadastro@cocobit.com.br";
            WebMail.Password = "brunoramonyan";

            string assunto = "confirmação de email";

            string mensagem = "Para ativar sua conta no sistema de auto escola, você deve acessar o link abaixo" +
                @"http://www.cocobit.com.br/autoescola/usuario/confirmacao/chave="+usuario.CodigoAtivacao;


            WebMail.Send(usuario.Email, assunto, mensagem);
        }

    }
}
