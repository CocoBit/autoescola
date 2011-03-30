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

        [HttpPost]
        public string ImportarAluno(Pessoa pessoa, Empresa empresa)
        {
            try
            {
                var empresaTemp = reporitoryEmpresa.Find(2);
                if (repository.FindByEmpresaAndPessoa(empresaTemp, pessoa) != null)
                    throw new Exception("O CPF do aluno já possui cadastro no sistema cadastrado no sistema");

                Aluno model = new Aluno();
                model.Empresa = empresaTemp;
                model.Pessoa = pessoa;
                //model.Pessoa.Endereco = new Endereco();
                //model.Pessoa.Contato = new Contato();
                repository.Create(model);

                return "Deu certo";
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message;
            }
        }
    }
}
