using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using AutoEscola.Models;

namespace AutoEscola.Contexts.Models
{
    public class AutoEscolaContext : DbContext
    {
        public AutoEscolaContext() : base("MySqlConnection") { }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().ToTable("empresa");
            modelBuilder.Entity<Usuario>().ToTable("usuario");
        }
    }
}
