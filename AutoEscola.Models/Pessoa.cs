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
        public string Nome { get; set; }
        [Required(ErrorMessage="É necessário informar o CPF")]
        public string CPF { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Contato Contato { get; set; }

        public Pessoa()
        {
        }
    }
}
