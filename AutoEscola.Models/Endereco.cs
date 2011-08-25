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
        public Endereco()
        {
            this.BairroEndereco = new Bairro();
        }

        public int Id { get; set; }
        public int BairroId { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        [Display(Name = "Endereço (Rua, Av. etc)")]
        public string Logradouro { get; set; }
        
        public string Cep { get; set; }

        [ForeignKey("BairroId")]
        public virtual Bairro BairroEndereco { get; set; }
    }
}
