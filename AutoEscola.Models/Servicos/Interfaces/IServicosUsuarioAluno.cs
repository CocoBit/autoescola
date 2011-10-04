using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoEscola.Models.Servicos.Interfaces
{
    public interface IServicosUsuarioAluno: IServicosUsuario
    {
        void CriarContaDeUsuarioAluno(Usuario usuario);
    }
}
