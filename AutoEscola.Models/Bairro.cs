using System.ComponentModel;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Models
{
    public class Bairro: IModel
    {
        public int Id { get; set; }
        [DisplayName("Bairro")]
        public string Nome { get; set; }
    }
}
