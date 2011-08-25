using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;
using AutoEscola.Models;

namespace AutoEscola.Areas.Alunos.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Alunos/Usuario/

        private IUsuarioRepository usuarioRepository;
        private IPessoaRepository pessoaRepository;
        private const string PERFIL_ALUNOS = "role_alunos";

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
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                AssociarPessoaAoUsuario(usuario);

                if (!UsuarioValidoParaCadastro(usuario))
                    return View(usuario);

                usuario.GerarChaveDeAtivacao();
                usuarioRepository.Criar(usuario, PERFIL_ALUNOS);

                return RedirectToAction("Index", "HomeAlunos");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult logar(FormCollection formulario)
        {
            var usuario = formulario["usuario"];
            var senha = formulario["senha"];

            try
            {
                if (usuarioRepository.Validar(usuario, senha, PERFIL_ALUNOS))
                    return RedirectToAction("Detalhes", "Ocorrencias");
                else
                {
                    ModelState.AddModelError("", "Usuário não localizado.");
                    return RedirectToAction("Index", "HomeAluno");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Erro ao autenticar usuario: " + ex.Message);
                return RedirectToAction("Index", "HomeAluno");
            }
        }

        private bool UsuarioValidoParaCadastro(Usuario usuario)
        {
            return ((PessoaPodeSerAssociadaAoUsuario(usuario.Pessoa)) || (EmailValidoParaCadastro(usuario)));
        }

        private bool EmailValidoParaCadastro(Usuario usuario)
        {
            if (!usuarioRepository.EmailValidoParaCadastro(usuario.Email))
            {
                ViewBag.Message = string.Format("O endereço eletrônico {0} já cadastrado. Tentre outro endereço", usuario.Email);
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
                ViewBag.Message = "Não há registro deste CPF para realização de cadastro para este usuário";
                return false;
            }
            else if (pessoaRepository.ExisteUmUsuarioCadastradoParaPessoa(pessoa))
            {
                ViewBag.Message = string.Format("O proprietário do CPF '{0}' já possui um usuário associado", pessoa.CPF);
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
