using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoEscola.Models.Servicos.Interfaces
{
    public interface IServicosUsuario : IServicosValidacao
    {
        bool Logar(string login, string senha);

        void Desconectar();
    }
}
