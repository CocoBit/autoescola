using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Models;
using AutoEscola.Contexts.Models;

namespace AutoEscola.Repository
{
    class PessoaRepository : IPessoaRepository
    {
        private AutoEscolaContext _context;

        public PessoaRepository(AutoEscolaContext context)
        {
            _context = context;
        }

        public Pessoa FindByCpf(string cpf)
        {
            var pessoas = _context.Pessoas.Where(p => p.CPF == cpf);
            if (pessoas.Count() == 0)
                return null;
            else
                return pessoas.Single();
        }

        public void Create(Pessoa model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pessoa model)
        {
            throw new NotImplementedException();
        }

        public void Update(Pessoa model)
        {
            throw new NotImplementedException();
        }

        public Pessoa Find(int id)
        {
            var pessoas = _context.Pessoas.Where(p => p.Id == id);
            return pessoas.Count() == 0 ? null : pessoas.First();

        }

        public List<Pessoa> All()
        {
            throw new NotImplementedException();
        }
    }
}
