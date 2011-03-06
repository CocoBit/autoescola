using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Repository.Interfaces;
using AutoEscola.Models;
using AutoEscola.Contexts.Models;

namespace AutoEscola.Repository.Factory
{
    public static class RepositoryFactory
    {
        private static AutoEscolaContext context = new AutoEscolaContext(); 

        public static IRepository<Empresa> CreateEmpresaRepository()
        {
            return new EmpresaRepository(context);
        }

        public static IRepository<Aluno> CreateAlunoRepository()
        {
            return new AlunoRepository(context);
        }


        public static IUsuarioRepository CreateUsuarioRepository()
        {
            return new UsuarioRepository(context);
        }
    }
}
