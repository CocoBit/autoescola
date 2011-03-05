using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoEscola.Interfaces.Models;


namespace AutoEscola.Models
{
    public class Contato : IModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string Fax { get; set; }

    }
}
