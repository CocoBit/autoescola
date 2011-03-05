using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;

namespace AutoEscola.Models
{
    public class Bairro: IModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
