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

        public EmpresaController()
        {
            repository = RepositoryFactory.CreateEmpresaRepository();
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
        public ActionResult Create(Empresa model)
        {
            repository.Create(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var empresa = repository.Find(id);
            return View(empresa);
        }
    
    }
}
