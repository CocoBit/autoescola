using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Models.Repositories;

namespace AutoEscola.Models.Sevices.Interfaces
{
    public interface IServicosUsuario: IValidadorServico
    {
        void CriarNovoUsuario(Usuario usuario);

        bool Logar(string login, string senha);

        void Desconectar();
    }
}
