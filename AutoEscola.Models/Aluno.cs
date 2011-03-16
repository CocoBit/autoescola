using System.ComponentModel.DataAnnotations;
using AutoEscola.Interfaces.Models;


namespace AutoEscola.Models
{
    public class Aluno : IModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        public string RegistroGeral { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MaxLength(11, ErrorMessage="CPF inválido")]
        public string CPF { get; set; }
        public string CaminhoDaFoto { get; set; }

        public virtual Endereco EnderecoAluno { get; set; }
        public virtual Contato ContatoAluno { get; set; }
        public virtual Empresa Empresa { get; set; }
        
        public Aluno()
        {
            EnderecoAluno = new Endereco();
            ContatoAluno = new Contato();
            Empresa = new Empresa();
        }


    }
}
