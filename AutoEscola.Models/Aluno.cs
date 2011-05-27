using System.ComponentModel.DataAnnotations;
using AutoEscola.Interfaces.Models;
using System.Collections.Generic;


namespace AutoEscola.Models
{
    public class Aluno : IModel
    {
        public int Id { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public string RegistroGeral { get; set; }
        public string CaminhoDaFoto { get; set; }

        public virtual ICollection<Ocorrencia> Ocorrencias { get; set; }
    }
}
