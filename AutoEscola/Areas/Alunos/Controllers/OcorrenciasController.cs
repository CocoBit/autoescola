using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoEscola.Models;
using AutoEscola.Models.Repositories;

namespace AutoEscola.Areas.Alunos.Controllers
{
    [Authorize(Roles = "role_alunos")]
    public class OcorrenciasController : Controller
    {
        IAlunoRepository alunoRepository;

        public OcorrenciasController(IAlunoRepository alunoRepository)
        {
            this.alunoRepository = alunoRepository;
        }
        
        public ActionResult Detalhes()
        {
            Aluno aluno = alunoRepository.ProcurarPorIdPessoa(Sessao.Usuario.PessoaId);
            return View(aluno);
        }
    }
}
