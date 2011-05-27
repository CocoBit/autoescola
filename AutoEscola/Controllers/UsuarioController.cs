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
using System.Web.Security;

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
                var pessoa = pessoaRepository.FindByCpf(usuario.Pessoa.CPF);

                if (pessoa == null)
                {
                    ViewBag.Message = "Não foi identificado cadastro liberado para este CPF";
                    return View(usuario);
                }

                if (Membership.GetUserNameByEmail(usuario.Email) != null)
                {
                    ViewBag.Message = "Não foi identificado cadastro liberado para este CPF";
                    return View(usuario);
                }

                usuario.Pessoa = pessoa;
                usuario.GerarChaveDeAtivacao();
                usuarioRepository.Create(usuario);

                Membership.CreateUser(usuario.Login, usuario.Senha, usuario.Email);

                return RedirectToAction("Conectar", "Acesso");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
