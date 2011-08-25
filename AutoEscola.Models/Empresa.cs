using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Models
{
    public class Empresa: IModel
    {
        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "A Razão social é obrigatória")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
        [ForeignKey("ContatoId")]
        public virtual Contato Contato { get; set; }
    }
}
