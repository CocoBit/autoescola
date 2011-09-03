using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Models;
using System.Data.Entity;
using AutoEscola.Contexts.Models;

namespace AutoEscola.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private AutoEscolaContext _context;

        public AlunoRepository(AutoEscolaContext context)
        {
            _context = context;
        }

        public Aluno ProcurarPorIdPessoa(int id)
        {
            var aluno = _context.Alunos.Where(a => a.Pessoa.Id == id);
            return aluno.Count() > 0 ? aluno.Single() : null;
        }
    }
}
