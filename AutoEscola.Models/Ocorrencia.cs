using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Models
{
    public class Ocorrencia: IModel
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string CPF { get; set; }
        public string Descricao { get; set; }
        public string Operador { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}
