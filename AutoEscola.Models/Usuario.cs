using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Models
{
    public class Usuario:IModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public virtual Empresa EmpresaUsuario { get; set; }
    }
}
