using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Contexts.Models;
using AutoEscola.Models;

namespace AutoEscola.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private AutoEscolaContext _context;

        public UsuarioRepository(AutoEscolaContext context)
        {
            _context = context;
        }

        public void Create(Usuario model)
        {
            _context.Usuarios.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Usuario model)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario model)
        {
            throw new NotImplementedException();
        }

        public Usuario Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> All()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindByEmpresa(Empresa empresa)
        {
            var usuarios = _context.Usuarios.Where(u => u.Empresa.Id == empresa.Id);
            return usuarios.ToList();
        }
    }
}
