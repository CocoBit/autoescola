using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Models.Repositorios
{
    public interface IRepositorioPessoa
    {
        Pessoa ProcurarPessoaPorCpf(string cpf);
        bool PessoaPossuiUmUsuarioCadastrado(Pessoa model);
    }
}
