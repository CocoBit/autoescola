using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoEscola.Models
{
    public class Pessoa: IModel
    {
        public int Id { get; set; }
        public int? EnderecoId { get; set; }
        public int? EmpresaId { get; set; }
        public int? ContatoId { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage="É necessário informar o CPF")]
        public string CPF { get; set; }

        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }

        [ForeignKey("ContatoId")]
        public virtual Contato Contato { get; set; }

        [ForeignKey("EmpresaId")]
        public virtual Empresa Empresa { get; set; }
    }
}
