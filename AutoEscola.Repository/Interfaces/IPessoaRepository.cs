using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Repository.Interfaces
{
    public interface IPessoaRepository: IRepository<Pessoa>
    {
        Pessoa ProcurarPessoaPorCpf(string cpf);
        bool ExisteUmUsuarioCadastradoParaPessoa(Pessoa model);
    }
}
