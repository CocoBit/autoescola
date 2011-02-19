using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace AutoEscola.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="O CNPJ é obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "A Razão social é obrigatória")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }
        
        public string Site { get; set; }
    }

    public class DaoEmpresa : DbContext
    {
        public DaoEmpresa() : base("MySqlConnection") { }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().ToTable("empresa");
        }
    }
}