using System.ComponentModel.DataAnnotations;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Models
{
    public class Bairro: IModel
    {
        public int Id { get; set; }
        [Display(Name = "Bairro")]
        public string Nome { get; set; }
    }
}
