﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using AutoEscola.Interfaces.Models;
using System.Security.Cryptography;

namespace AutoEscola.Models
{
    public class Usuario : IModel
    {

        private const string regexEmail = @"^(([^<>()[\]\\.,;:\s@\""]+"
                                        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                                        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                                        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                                        + @"[a-zA-Z]{2,}))$";

        public int Id { get; set; }

        [Required(ErrorMessage = "O login é obrigatória")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [RegularExpression(regexEmail)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public string CodigoAtivacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public string GerarChaveDeAtivacao()
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(this.Pessoa.CPF);
            SHA1Managed SHhash = new SHA1Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
                strHex += String.Format("{0:x2}", b);
            
            this.CodigoAtivacao = strHex;

            return strHex;
        }

    }
}
