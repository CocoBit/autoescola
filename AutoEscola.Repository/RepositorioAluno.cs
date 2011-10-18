using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;
using System.Data.Entity;
using AutoEscola.Contexts.Models;
using AutoEscola.Models.Repositorios;

namespace AutoEscola.Repository
{
    public class RepositorioAluno : IRepositorioAluno
    {
        private AutoEscolaContext _context;

        public RepositorioAluno(AutoEscolaContext context)
        {
            _context = context;
        }

        public Aluno ProcurarPorIdPessoa(int id)
        {
            var alunos = _context.Alunos.Where(a => a.Pessoa.Id == id);
            return alunos.Count() == 0? null : alunos.First();
        }
    }
}
