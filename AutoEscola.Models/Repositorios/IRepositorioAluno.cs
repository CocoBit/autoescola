using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Models.Repositorios
{
    public interface IRepositorioAluno
    {
        Aluno ProcurarPorIdPessoa(int id);
    }
}
