using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;
using AutoEscola.Contexts.Models;

namespace AutoEscola.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        IUsuarioRepository usuarioRepository;
        IRepository<Empresa> empresaRepository;

        public UsuarioController()
        {
            usuarioRepository = RepositoryFactory.CreateUsuarioRepository();
            empresaRepository = RepositoryFactory.CreateEmpresaRepository();
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
            // TODO: Buscar pessoa por CPF Se não existir abortar
            // TODO: Criar código de ativação do aluno
            usuarioRepository.Create(usuario);
            // TODO: Enviar email de confirmação
            
            return View(usuario);
        }

    }
}
