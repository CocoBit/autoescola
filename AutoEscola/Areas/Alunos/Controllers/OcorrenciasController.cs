using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Repository.Factory;

namespace AutoEscola.Areas.Alunos.Controllers
{
    [Authorize(Roles = "role_alunos")]
    public class OcorrenciasController : Controller
    {
        //
        // GET: /Alunos/Ocorrencias/

        IAlunoRepository repository;
        //IOcorrenciaRepositoy repositorioOcorrencia;

        public OcorrenciasController()
        {
            repository = RepositoryFactory.CreateAlunoRepository();
        }
        
        public ActionResult Detalhes()
        {
            Aluno aluno = repository.ProcurarPorIdPessoa(Sessao.Usuario.PessoaId);
            return View(aluno);
        }
    }
}
