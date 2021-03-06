﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;
using System.ComponentModel.DataAnnotations;


namespace AutoEscola.Models
{
    public class Aluno : IModel
    {
        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public int EmpresaId { get; set; }
        public int ContatosId { get; set; }
        
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome{ get; set; }
        public string RegistroGeral { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(11)]
        public string CPF { get; set; }
        public string CaminhoDaFoto { get; set; }

        public virtual Endereco EnderecoAluno { get; set; }
        public virtual Contato ContatoAluno { get; set; }
        public virtual Empresa Empresa { get; set; }
        
        public Aluno()
        {
            EnderecoAluno = new Endereco();
            ContatoAluno = new Contato();

        }


    }
}
