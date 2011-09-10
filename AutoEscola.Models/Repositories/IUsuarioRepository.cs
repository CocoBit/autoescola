using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models;

namespace AutoEscola.Models.Repositories
{
    public interface IUsuarioRepository
    {
        bool Validar(string login, string password, string perfil);
        bool EmailValidoParaCadastro(string email);
        void Criar(Usuario usuario, string perfil);
        bool Ativar(string chave);
    }
}
