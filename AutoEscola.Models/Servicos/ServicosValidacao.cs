using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoEscola.Models.Servicos
{
    public class ServicosValidacao
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

        public bool ExisteErros()
        {
            return _Erros.Count > 0;
        }

        public string[] Erros()
        {
            return _Erros.ToArray();
        }
    }
}
