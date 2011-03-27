using System.ComponentModel.DataAnnotations;
using AutoEscola.Interfaces.Models;


namespace AutoEscola.Models
{
    public class Aluno : IModel
    {
        public int Id { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public string RegistroGeral { get; set; }
        public string CaminhoDaFoto { get; set; }

        public Aluno()
        {
            Empresa = new Empresa();
            Pessoa = new Pessoa();
        }
    }
}
