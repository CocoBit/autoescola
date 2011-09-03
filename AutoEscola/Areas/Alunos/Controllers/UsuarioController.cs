using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;
using AutoEscola.Models;
using AutoEscola.Controllers;

namespace AutoEscola.Areas.Alunos.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Alunos/Usuario/

        private IUsuarioRepository usuarioRepository;
        private IPessoaRepository pessoaRepository;
        private const string PERFIL_ALUNOS = "role_alunos";
        private static List<string> Mensagens = new List<string>();

        public UsuarioController()
        {
            usuarioRepository = RepositoryFactory.CreateUsuarioRepository();
            pessoaRepository = RepositoryFactory.CreatePessoaRepository();
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
            AssociarPessoaAoUsuario(usuario);

            if (!UsuarioValidoParaCadastro(usuario))
                return View(usuario);

            usuario.GerarChaveDeAtivacao();
            usuarioRepository.Criar(usuario, PERFIL_ALUNOS);
            EnviarEmail(usuario);

            return RedirectToAction("Index", "HomeAlunos");
        }

        private static void EnviarEmail(Usuario usuario)
        {
            var mensagem = "Foi realiza uma solicitação de ativação de sua conta no " +
                           "Sistema Auto Escola Simples. Caso deseje realmente ativá-la," +
                           " acesse o linque a baixo" +
                           "\r\n" +
                           "\r\n" +
                           "http://www.autoescolasimples.com.br/alunos/ativacao/?chave=" + usuario.CodigoAtivacao;

            Helpers.Contato contato = new Helpers.Contato();
            contato.Enviar("teste", usuario.Email, "Ativação de conta", mensagem);
        }

        [HttpPost]
        [HandleError]
        public ActionResult logar(FormCollection formulario)
        {
            Mensagens.Clear();
            var usuario = formulario["usuario"];
            var senha = formulario["senha"];

            if (usuarioRepository.Validar(usuario, senha, PERFIL_ALUNOS))
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
            return ((PessoaPodeSerAssociadaAoUsuario(usuario.Pessoa)) || (EmailValidoParaCadastro(usuario)));
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

        private void AssociarPessoaAoUsuario(Usuario usuario)
        {
            Pessoa pessoa = pessoaRepository.ProcurarPessoaPorCpf(usuario.Pessoa.CPF);
            usuario.Pessoa = pessoa;
        }

        private bool PessoaPodeSerAssociadaAoUsuario(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                Mensagens.Add("Não há registro deste CPF para realização de cadastro para este usuário");
                return false;
            }
            else if (pessoaRepository.ExisteUmUsuarioCadastradoParaPessoa(pessoa))
            {
                Mensagens.Add(string.Format("O proprietário do CPF '{0}' já possui um usuário associado", pessoa.CPF));
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
