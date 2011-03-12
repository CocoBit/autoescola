using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Repository;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;
using AutoEscola.Contexts.Models;

namespace AutoEscola.Controllers
{
    public class EmpresaController : Controller
    {
        IRepository<Empresa> repository;
        IUsuarioRepository usuarioRepository;

        public EmpresaController()
        {
            repository = RepositoryFactory.CreateEmpresaRepository();
            usuarioRepository = RepositoryFactory.CreateUsuarioRepository();
        }

        public ActionResult Index()
        {
            return View(repository.All());
        }
        
        public ActionResult Create()
        {
            var empresa = new Empresa();
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Create(Empresa empresa, Endereco endereco, Contato contato)
        {
            empresa.EnderecoEmpresa = endereco;
            empresa.ContatoEmpresa = contato;
            repository.Create(empresa);

            var usuario = new Usuario();
            usuario.Empresa = empresa;
            usuario.Login = empresa.ContatoEmpresa.Email;
            usuario.Senha = "Admin";
            usuarioRepository.Create(usuario);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var empresa = repository.Find(id);
            return View(empresa);
        }
    
    }
}
