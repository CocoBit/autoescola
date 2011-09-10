using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Models.Repositories
{
    public interface IPessoaRepository
    {
        Pessoa ProcurarPessoaPorCpf(string cpf);
        bool ExisteUmUsuarioCadastradoParaPessoa(Pessoa model);
    }
}
