using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Controllers;
using AutoEscola.Models.Repositories;
using AutoEscola.Models.Sevices.Interfaces;
using AutoEscola.Models.Sevices;
using AutoEscola.Helpers;

namespace AutoEscola.Areas.Alunos.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository UsuarioRepository;
        private IPessoaRepository PessoaRepository;
        private IServicosUsuario ServicosUsuario;

        public UsuarioController(IUsuarioRepository usuarioRepository, IPessoaRepository pessoaRepository)
        {
            this.UsuarioRepository = usuarioRepository;
            this.PessoaRepository = pessoaRepository;
            this.ServicosUsuario = new ServicosUsuarioAluno(usuarioRepository, pessoaRepository);
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
            ServicosUsuario.CriarNovoUsuario(usuario);

            if (ServicosUsuario.PossuiErros())
            {
                foreach (string mensagem in ServicosUsuario.Erros())
                    ModelState.AddModelError("", mensagem);
                return View(usuario);
            }

            EnviarEmail(usuario);

            return RedirectToAction("ConfirmarCadastro", "Ativacao");
        }

        private void EnviarEmail(Usuario usuario)
        {
            var mensagem = "<html><p>" + 
                           "Foi realiza uma solicitaÃ§Ã£o de ativaÃ§Ã£o de sua conta no " +
                           "Sistema Auto Escola Simples. Caso deseje realmente ativÃ¡-la," +
                           " acesse o linque a baixo" +
                           "<br/>" +
                           "<br/>" +
                           "<a href=\"http://www.autoescolasimples.com.br/alunos/ativacao/?chave=" + usuario.CodigoAtivacao + "\">Clique aqui para ativar sua conta</a>" +
                           "</p></html>";

            Email email = new Email();
            email.Enviar("teste", usuario.Email, "AtivaÃ§Ã£o de conta", mensagem);
        }

        [HttpPost]
        [HandleError]
        public ActionResult logar(FormCollection formulario)
        {
            var usuario = formulario["usuario"];
            var senha = formulario["senha"];

            if (ServicosUsuario.Logar(usuario, senha))
                return RedirectToAction("Detalhes", "Ocorrencias");
            else
                return RedirectToAction("Error");
        }

        public ActionResult Error()
        {
            foreach (string mensagem in ServicosUsuario.Erros())
                ModelState.AddModelError("", mensagem);

            return View();
        }

        [HttpGet]
        public ActionResult Desconectar()
        {
            ServicosUsuario.Desconectar();
            return RedirectToAction("Index", "Home");
        }

    }
}
