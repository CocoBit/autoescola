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
    public class RepositorioEmpresa: IRepositorioEmpresa
    {
        private AutoEscolaContext _context;

        public RepositorioEmpresa(AutoEscolaContext context)
        {
            _context = context;
        }


        public Empresa ProcurarPorCnpj(string cnpj)
        {
            var empresas = from empresa in _context.Empresas
                           where empresa.CNPJ == cnpj
                           select empresa;

            return empresas.Count() > 0 ? empresas.First() : null;
        }

        public void Cadastrar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
        }
    }
}
