﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Models;
using System.Data.Entity;
using AutoEscola.Contexts.Models;

namespace AutoEscola.Repository
{
    class EmpresaRepository: IEmpresaRepository
    {
        private AutoEscolaContext _context;

        public EmpresaRepository(AutoEscolaContext context)
        {
            _context = context;
        }

        public void Create(Empresa model)
        {
            try
            {
                _context.Empresas.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Empresa model)
        {
            _context.Empresas.Remove(model);
        }

        public void Update(Empresa model)
        {
            throw new NotImplementedException();
        }

        public Empresa Find(int id)
        {
            var empresa = _context.Empresas.Where(e => e.Id == id).Single();
            return empresa;
        }

        public Empresa FindByCnpj(string cnpj)
        {
            var empresa = _context.Empresas.Where(e => e.CNPJ.Equals(cnpj));
            return empresa.Count() > 0 ? empresa.Single() : null;
        }

        public List<Empresa> All()
        {
            return _context.Empresas.ToList();
        }
    }
}
