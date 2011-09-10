using System.ComponentModel.DataAnnotations;

namespace AutoEscola.Models
{
    public class Bairro
    {
        public int Id { get; set; }

        [Display(Name = "Bairro")]
        public string Nome { get; set; }
    }
}
