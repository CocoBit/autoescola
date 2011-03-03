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
        public static IEmpresaRepository CreateEmpresaRepository()
        {
            var context = new AutoEscolaContext();
            return new EmpresaRepository(context);
        }
    }
}
