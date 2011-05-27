using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;

namespace AutoEscola.Controllers
{
    public class ImportacaoController : Controller
    {
        //
        // GET: /Importacao/

        IAlunoRepository repository;
        IEmpresaRepository reporitoryEmpresa;


        public ImportacaoController()
        {
            repository = RepositoryFactory.CreateAlunoRepository();
            reporitoryEmpresa = RepositoryFactory.CreateEmpresaRepository();
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}
