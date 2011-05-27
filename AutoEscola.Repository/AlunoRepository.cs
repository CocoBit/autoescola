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

        public void Create(Aluno model)
        {
            try
            {
                _context.Alunos.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Aluno model)
        {
            _context.Alunos.Remove(model);
        }

        public void Update(Aluno model)
        {
            throw new NotImplementedException();
        }

        public Aluno FindByPessoa(Pessoa pessoa)
        {
            if (pessoa == null)
                return null;

            var aluno = _context.Alunos.Where(a => a.Pessoa.Id == pessoa.Id);
            return aluno.Count() > 0 ? aluno.Single() : null;
        }

        public Aluno FindByEmpresaAndPessoa(Empresa empresa, Pessoa pessoa)
        {
            return null;
        }

        public Aluno Find(int id)
        {
            var aluno = _context.Alunos.Where(e => e.Id == id && e.Pessoa.Id != -1);
            return aluno.Count() == 0 ? null : aluno.First();
        }

        public List<Aluno> All()
        {
            return _context.Alunos.ToList();
        }


    }
}
