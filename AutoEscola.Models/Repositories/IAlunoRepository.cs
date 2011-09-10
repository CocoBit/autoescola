using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Models.Repositories
{
    public interface IAlunoRepository
    {
        Aluno ProcurarPorIdPessoa(int id);
    }
}
