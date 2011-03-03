using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Repository.Interfaces
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        //Todo
        List<Usuario> FindByEmpresa(Empresa empresa);
    }
}
