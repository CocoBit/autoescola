using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoEscola.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Descricao { get; set; }
        public string Operador { get; set; }
    }
}
