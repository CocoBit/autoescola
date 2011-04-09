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
        IAlunoRepository repository;

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
            aluno.Pessoa.Endereco = new Endereco();
            aluno.Pessoa.Contato = new Contato();
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Create(Aluno model, Endereco endereco, Contato contato, Pessoa pessoa, FormCollection form)
        {
            var reporitoryEmpresa = RepositoryFactory.CreateEmpresaRepository();

            var emp = reporitoryEmpresa.Find(2);
            if (emp == null)
                emp = new Empresa() { CNPJ = "00000000001234", NomeFantasia = "Teste", RazaoSocial = "Teste" };
            
            model.Empresa = emp;
            model.Pessoa = pessoa;
            model.Pessoa.Endereco = endereco;
            model.Pessoa.Contato = contato;
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
