using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;

namespace AutoEscola.Controllers
{
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/

        DaoEmpresa Dao = new DaoEmpresa();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var empresa = new Empresa();
            return View(empresa);
        }

        [HttpPost]
        public ActionResult Create(Empresa model)
        {
            Dao.Empresas.Add(model);
            Dao.SaveChanges();

            return RedirectToAction("Index");
        }
    
    }
}
