using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Models.Repositorios
{
    public interface IRepositorioEmpresa
    {
        Empresa ProcurarPorCnpj(string cnpj);

        void Cadastrar(Empresa empresa);
    }
}
