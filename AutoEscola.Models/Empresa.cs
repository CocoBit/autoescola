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

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "A Razão social é obrigatória")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        public virtual Endereco EnderecoEmpresa { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }

    }
}
