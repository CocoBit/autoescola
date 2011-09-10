using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace AutoEscola.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }

        public string RegistroGeral { get; set; }
        public string CaminhoDaFoto { get; set; }

        [ForeignKey("PessoaId")]
        public virtual Pessoa Pessoa { get; set; }

        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }
    }
}
