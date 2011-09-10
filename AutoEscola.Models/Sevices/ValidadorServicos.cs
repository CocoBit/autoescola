using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoEscola.Models.Sevices
{
    public class ValidadorServicos
    {
        private static List<string> _Erros = new List<string>();

        protected void ApagarErros()
        {
            _Erros.Clear();
        }

        protected void AdicionarErro(string mensagem)
        {
            _Erros.Add(mensagem);
        }

        public bool PossuiErros()
        {
            return _Erros.Count > 0;
        }

        public string[] Erros()
        {
            return _Erros.ToArray();
        }
    }
}
