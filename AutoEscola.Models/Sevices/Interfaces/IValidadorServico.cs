using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoEscola.Models.Sevices.Interfaces
{
    public interface IValidadorServico
    {
        bool PossuiErros();

        string[] Erros();
    }
}
