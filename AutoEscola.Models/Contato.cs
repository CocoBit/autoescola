using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;
using System.ComponentModel.DataAnnotations;


namespace AutoEscola.Models
{
    public class Contato : IModel
    {
        private const string regexEmail = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                        + @"[a-zA-Z]{2,}))$";

        public int Id { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [Display(Name = "Email")]
        [RegularExpression(regexEmail, ErrorMessage="Email informádo encontra-se em um formato inválido")]
        public string Email { get; set; }

        [Display(Name = "twitter")]
        public string Twitter { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }
    }
}
