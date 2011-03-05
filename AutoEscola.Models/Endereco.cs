using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoEscola.Models
{
    public class Endereco: IModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório")]
        [MaxLength(2)]
        public string UF { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        
        public string Cep { get; set; }

        public virtual Bairro BairroEndereco { get; set; }
    }
}
