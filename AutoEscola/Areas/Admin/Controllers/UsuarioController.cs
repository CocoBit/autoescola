using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Models.Repositories;

namespace AutoEscola.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository usuarioRepository;
        private IPessoaRepository pessoaRepository;
        private static List<string> Mensagens = new List<string>();

        private const string PERFIL_ADMIN = "role_admin";


        public UsuarioController(IUsuarioRepository usuarioRepository, IPessoaRepository pessoaRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.pessoaRepository = pessoaRepository;
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
            if (!UsuarioValidoParaCadastro(usuario))
                return View(usuario);

            usuario.GerarChaveDeAtivacao();
            usuarioRepository.Criar(usuario, PERFIL_ADMIN);
            EnviarEmail(usuario);

            return RedirectToAction("ConfirmarCadastro", "Ativacao");
        }

        private static void EnviarEmail(Usuario usuario)
        {
            var mensagem = "Foi realiza uma solicitação de ativação de sua conta no " +
                           "Sistema Auto Escola Simples. Caso deseje realmente ativá-la," +
                           " acesse o linque a baixo" +
                           "\r\n" +
                           "\r\n" +
                           "http://www.autoescolasimples.com.br/alunos/ativacao/?chave=" + usuario.CodigoAtivacao;

            Helpers.Email contato = new Helpers.Email();
            contato.Enviar("teste", usuario.Email, "Ativação de conta", mensagem);
        }

        [HttpPost]
        [HandleError]
        public ActionResult logar(FormCollection formulario)
        {
            Mensagens.Clear();
            var usuario = formulario["usuario"];
            var senha = formulario["senha"];

            if (usuarioRepository.Validar(usuario, senha, PERFIL_ADMIN))
                return RedirectToAction("Detalhes", "Ocorrencias");
            else
            {
                Mensagens.Add("Usuário / e-mail e senhas inválidos.");
                return RedirectToAction("error");
            }
        }

        public ActionResult error()
        {
            foreach (string mensagem in Mensagens)
                ModelState.AddModelError("", mensagem);

            return View();
        }

        private bool UsuarioValidoParaCadastro(Usuario usuario)
        {
            return (EmailValidoParaCadastro(usuario));
        }

        private bool EmailValidoParaCadastro(Usuario usuario)
        {
            if (!usuarioRepository.EmailValidoParaCadastro(usuario.Email))
            {
                Mensagens.Add("e-mail inválido. Tentre outro endereço");
                return false;
            }
            return true;
        }

        [HttpGet]
        public ActionResult Desconectar()
        {
            Sessao.Sair();
            return RedirectToAction("Index", "Home");
        }
    }
}
