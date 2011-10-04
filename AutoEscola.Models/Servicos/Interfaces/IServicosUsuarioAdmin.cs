using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoEscola.Models.Servicos.Interfaces
{
    public interface IServicosUsuarioAdmin: IServicosUsuario
    {
        void CriarContaDeUsuarioSuperAdminFree(Usuario usuario);

        bool LogarFreeTour(string login, string senha);

    }
}
