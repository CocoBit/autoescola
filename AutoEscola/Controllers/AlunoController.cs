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
    public class AlunoController : Controller
    {
        IRepository<Aluno> repository;

        public AlunoController()
        {
            repository = RepositoryFactory.CreateAlunoRepository();
        }


        public ActionResult Index()
        {
            return View(repository.All());
        }


        public ActionResult Details(int id)
        {
            var aluno = repository.Find(id);
            return View(aluno);
        }

        public ActionResult Create()
        {
            var aluno = new Aluno();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Create(Aluno model)
        {
            repository.Create(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Aluno model)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id, Aluno model)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
