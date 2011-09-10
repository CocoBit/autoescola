using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;
using AutoEscola.Contexts.Models;
using AutoEscola.Models.Repositories;

namespace AutoEscola.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private AutoEscolaContext _context;

        public PessoaRepository(AutoEscolaContext context)
        {
            _context = context;
        }

        public Pessoa ProcurarPessoaPorCpf(string cpf)
        {
            var pessoas = _context.Pessoas.Where(p => p.CPF == cpf);
            return pessoas.Count() == 0 ? null : pessoas.First();
        }

        public void Criar(Pessoa model)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Pessoa model)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Pessoa model)
        {
            throw new NotImplementedException();
        }

        public Pessoa Buscar(int id)
        {
            var pessoas = _context.Pessoas.Where(p => p.Id == id);
            return pessoas.Count() == 0 ? null : pessoas.First();

        }

        public List<Pessoa> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public bool ExisteUmUsuarioCadastradoParaPessoa(Pessoa model)
        {
            var pessoas = _context.Usuarios.Where(u => u.Pessoa.Id == model.Id);
            return pessoas.Count() > 0;
        }

    }
}
