using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Repository;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;

namespace AutoEscola.Controllers
{
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/

        IEmpresaRepository repository;

        public ActionResult Index()
        {
            repository = RepositoryFactory.CreateEmpresaRepository();
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
            repository = RepositoryFactory.CreateEmpresaRepository();
            repository.Create(model);

            return RedirectToAction("Index");
        }
    
    }
}
