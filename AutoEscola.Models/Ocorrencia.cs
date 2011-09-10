using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AutoEscola.Models
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string CPF { get; set; }
        public string Descricao { get; set; }
        public string Operador { get; set; }

        [ForeignKey("AlunoId")]
        public virtual Aluno Aluno { get; set; }
    }
}
